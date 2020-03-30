using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class StructuredProperty : ILiquidizable
    {
        protected Models.Property Value { get; set; }
        public StructuredProperty(ODataApiGen.Models.Property prop)
        {
            this.Value = prop;
        }
        public abstract string Name { get; }

        public abstract string Type {get;}
        public object ToLiquid() {
            return new {
                Name = this.Name,
                Type = this.Type
            };
        }
    }
    public abstract class Structured : AngularRenderable, DotLiquid.ILiquidizable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Structured(StructuredType type)
        {
            EdmStructuredType = type;
        }

        public Angular.Structured Base { get; private set; }
        public void SetBase(Structured b)
        {
            this.Base = b;
            this.Dependencies.Add(b);
        }
        public Angular.Service Service {get; private set;}
        public void SetService(Service service)
        {
            this.Service = service;
            this.Dependencies.Add(service);
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
        public string EntityType => this.EdmStructuredType.FullName;
        public override string NameSpace => this.EdmStructuredType.Namespace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public string ResourcePath => this.Service?.ResourcePath;
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public abstract IEnumerable<Angular.StructuredProperty> Properties {get;} 

        protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
        {
            var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
            foreach (var name in names)
            {
                var callables = allCallables.Where(c => c.Name == name);
                var overload = callables.Count() > 1;
                var callable = callables.FirstOrDefault();
                var methodName = name[0].ToString().ToLower() + name.Substring(1);

                var callableFullName = callable.IsBound ? $"{callable.Namespace}.{callable.Name}" : callable.Name;

                var returnType = AngularRenderable.GetType(callable.ReturnType);

                var typescriptType = AngularRenderable.GetTypescriptType(callable.ReturnType);
                var callableReturnType = (callable.IsEdmReturnType || String.IsNullOrEmpty(returnType)) ?
                        $"{typescriptType}" :
                    callable.ReturnsCollection ?
                        $"{typescriptType}Collection" :
                        $"{typescriptType}Model" ;

                var parameters = new List<Models.Parameter>();
                foreach (var cal in callables)
                    parameters.AddRange(cal.Parameters);
                var optionals = parameters.Where(p =>
                    !callables.All(c => c.Parameters.Contains(p))).ToList();
                parameters = parameters.GroupBy(p => p.Name).Select(g => g.First()).ToList();

                var argumentWithType = new List<string>();

                argumentWithType.AddRange(parameters.Select(p =>
                    $"{p.Name}: {AngularRenderable.GetTypescriptType(p.Type)}" +
                    (p.IsCollection ? "[]" : "") +
                    (optionals.Contains(p) ? " = null" : "")
                ));
                argumentWithType.Add(@"options?: HttpOptions");

                var args = "let args = null;";
                if (parameters.Count() > 0) {
                    args = $"let args = Object.entries({{ {String.Join(", ", parameters.Select(p => p.Name))} }})" +
                    $"\n      .filter(pair => pair[1] !== null)" +
                    $"\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {{}});";
                }
                var call = (callable.IsEdmReturnType || String.IsNullOrEmpty(returnType)) ?
                        $"this.call<{typescriptType}>(res, args, 'value', options)" :
                    callable.ReturnsCollection ?
                        $"this.call<{typescriptType}, {typescriptType}Model, {typescriptType}Collection>(res, args, 'collection', options)" :
                        $"this.call<{typescriptType}, {typescriptType}Model>(res, args, 'model', options)";
                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{callableReturnType}> {{" +
                    $"\n    {args}" +
                    $"\n    var res = this.{callable.Type.ToLower()}<{typescriptType}>('{callableFullName}', '{returnType}');" +
                    $"\n    res.entitySet('{this.ResourcePath}');" +
                    $"\n    return {call};" +
                    "\n  }";
            }
        }
        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationProperty> navigations)
        {
            foreach (var nav in navigations)
            {
                var type = AngularRenderable.GetTypescriptType(nav.Type);
                var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);

                var methodCreateName = $"set{name}";

                var returnType = $"[{type}, ODataEntityAnnotations]";

                yield return $@"public {methodCreateName}(model: {type}Model | null): Observable<this> {{
    return this.setNavigationProperty<{type}, {type}Model>('{nav.Name}', model);
  }}";
            }
        }
        public abstract object ToLiquid();
    }
}