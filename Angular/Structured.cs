using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;
using Newtonsoft.Json;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public abstract class Structured : AngularRenderable, DotLiquid.ILiquidizable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Structured(StructuredType type, ApiOptions options) : base(options)
        {
            EdmStructuredType = type;
        }

        public Angular.Structured Base { get; private set; }
        public void SetBase(Structured b)
        {
            this.Base = b;
        }

        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var types = new List<string>();
                if (this.EdmStructuredType is EntityType)
                    types.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                types.AddRange(this.EdmStructuredType.Properties
                    .Where(a => !a.IsEdmType)
                    .Select(a => a.Type));
                types.AddRange(this.EdmStructuredType.Actions.Select(a => a.Type));
                types.AddRange(this.EdmStructuredType.Functions.Select(a => a.Type));
                if (this.Base != null)
                    types.Add(this.Base.EdmStructuredType.FullName);
                return types.Distinct();
            }
        }
        public override string Namespace => this.EdmStructuredType.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public string EntitySetName => Program.Metadata.Schemas.SelectMany(s => s.EntityContainers).SelectMany(c => c.EntitySets).FirstOrDefault(s => s.EntityType == this.EdmStructuredType.FullName)?.Name;
        public string EntityName => this.EdmStructuredType.Name; 
        public bool OpenType => this.EdmStructuredType.OpenType; 
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();

        protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables, bool useset = true, bool usename = false)
        {
            var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
            foreach (var name in names)
            {
                var callables = allCallables.Where(c => c.Name == name);
                var overload = callables.Count() > 1;
                var callable = callables.FirstOrDefault();
                var methodName = name.Substring(0, 1).ToLower() + name.Substring(1);

                var callableFullName = callable.IsBound ? $"{callable.Namespace}.{callable.Name}" : callable.Name;

                var typescriptType = this.ToTypescript(callable.ReturnType);
                var callableReturnType = (callable.IsEdmReturnType || String.IsNullOrEmpty(callable.ReturnType)) ?
                        $"{typescriptType}" :
                    callable.ReturnsCollection ?
                        $"{typescriptType}Collection<{typescriptType}, {typescriptType}Model<{typescriptType}>>" :
                        $"{typescriptType}Model<{typescriptType}>" ;

                var parameters = new List<Models.Parameter>();
                foreach (var cal in callables)
                    parameters.AddRange(cal.Parameters);
                var optionals = parameters.Where(p =>
                    !callables.All(c => c.Parameters.Contains(p))).ToList();
                parameters = parameters.GroupBy(p => p.Name).Select(g => g.First()).ToList();

                var argumentWithType = new List<string>();

                argumentWithType.AddRange(parameters.Select(p =>
                    $"{p.Name}: {this.ToTypescript(p.Type)}" +
                    (p.IsCollection ? "[]" : "") +
                    (optionals.Contains(p) ? " = null" : "")
                ));
                argumentWithType.Add(@"options?: HttpOptions");

                var args = "let args = null;";
                if (parameters.Count() > 0) {
                    args = "let args = Object.entries({" +
                        String.Join(", ", parameters.Select(p => p.IsEdmType ? 
                            $"\n        {p.Name}: {p.Name}":
                            $"\n        {p.Name}: this._resource.parserForType('{p.Type}').serialize({p.Name})")) +
                    "\n      })" +
                    "\n      .filter(pair => pair[1] !== null)" +
                    "\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});";
                }
                var mapTo = (callable.IsEdmReturnType || String.IsNullOrEmpty(callable.ReturnType)) ?
                        $"toValue(body)[0] as {callableReturnType}" :
                    callable.ReturnsCollection ?
                        $"toCollection<{callableReturnType}>(body)" :
                        $"toModel<{callableReturnType}>(body)";
                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{callableReturnType}> {{" +
                    $"\n    {args}" +
                    $"\n    var res = this._segment.{callable.Type.ToLower()}<{typescriptType}>('{callableFullName}'" +
                    (String.IsNullOrWhiteSpace(callable.ReturnType) ? ");" : $", '{callable.ReturnType}');") +
                    (useset ? $"\n    res.segment.entitySet('{this.EntitySetName}');" : "") +
                    (usename ? $"\n    options = Object.assign({{config: '{this.Options.Name}'}}, options || {{}});" : "") +
                    $"\n    return res.call(args, 'json', options).pipe(map((body: any) => res.{mapTo}));" +
                    "\n  }";
            }
        }
        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationPropertyBinding> bindings)
        {
            foreach (var binding in bindings)
            {
                var nav = binding.NavigationProperty;
                var type = this.ToTypescript(nav.Type);
                var methodName = nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1);

                var methodSetName = $"set{methodName}";

                var returnType = $"[{type}, ODataEntityAnnotations]";

                yield return $@"public {methodSetName}(model: {type}Model<{type}> | null): Observable<this> {{
    return this.setNavigationProperty<{type}, {type}Model<{type}>>('{nav.Name}', model);
  }}";
            }
        }
        public abstract object ToLiquid();
    }
}