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
        public Models.EntityType EdmEntityType => this.EdmStructuredType as Models.EntityType; 
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
                var list = new List<string>();
                if (this.EdmEntityType != null) {
                    list.AddRange((this.EdmEntityType as EntityType).Properties.Select(a => a.Type));
                    list.AddRange((this.EdmEntityType as EntityType).NavigationProperties.Select(a => a.Type));
                    list.AddRange((this.EdmEntityType as EntityType).NavigationProperties.Select(a => a.ToEntityType));
                    list.AddRange(this.EdmEntityType.Actions.Select(a => a.Type));
                    list.AddRange(this.EdmEntityType.Functions.Select(a => a.Type));
                }
                /*For Not-EDM types (e.g. enums with namespaces, complex types*/
                list.AddRange(this.EdmStructuredType.Properties
                    .Where(a => !a.IsEdmType)
                    .Select(a => a.Type));
                if (this.Base != null)
                    list.Add(this.Base.EdmStructuredType.FullName);
                return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
            }
        }
        public override string Namespace => this.EdmStructuredType.Namespace;
        public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
        public string EntitySetName => Program.Metadata.Schemas.SelectMany(s => s.EntityContainers).SelectMany(c => c.EntitySets).FirstOrDefault(s => s.EntityType == this.EdmStructuredType.FullName)?.Name;
        public bool OpenType => this.EdmStructuredType.OpenType; 
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

                var typescriptType = this.ToTypescriptType(callable.ReturnType);
                var callableReturnType = (callable.IsEdmReturnType || String.IsNullOrEmpty(callable.ReturnType)) ?
                        $"{typescriptType}" :
                    callable.ReturnsCollection ?
                        $"{typescriptType}Collection<{typescriptType}, {typescriptType}Model<{typescriptType}>>" :
                        $"{typescriptType}Model<{typescriptType}>" ;

                var parameters = new List<Models.Parameter>();
                var optionals = new List<string>();
                foreach (var cal in callables) {
                    foreach (var param in cal.Parameters) {
                        if (parameters.All(p => p.Name != param.Name))
                            parameters.Add(param);
                        if (optionals.All(o => o != param.Name) && !callables.All(c => c.Parameters.Any(p => p.Name == param.Name)))
                            optionals.Add(param.Name);
                    }
                }
                parameters = parameters.GroupBy(p => p.Name).Select(g => g.First()).ToList();

                var arguments = parameters.Select(p =>
                    $"{p.Name}" + 
                    (optionals.Any(o => o == p.Name) ? "?" : "") + 
                    $": {this.ToTypescriptType(p.Type)}" +
                    (p.IsCollection ? "[]" : ""));

                var args = new List<string>(arguments);
                args.Add("options?: HttpOptions");

                var types = "null";
                if (parameters.Count() > 0) {
                    types = $"{{{String.Join(", ", arguments)}}}";
                }

                var values = "null";
                if (parameters.Count() > 0) {
                    values = $"{{{String.Join(", ", parameters.Select(p => p.Name))}}}";
                }

                var responseType = (callable.IsEdmReturnType || String.IsNullOrEmpty(callable.ReturnType)) ?
                        $"property" :
                    callable.ReturnsCollection ?
                        $"collection" :
                        $"model";
                yield return $"public {methodName}({String.Join(", ", args)}): Observable<{callableReturnType}> {{" +
                    $"\n    var res = this._{callable.Type.ToLower()}<{types}, {typescriptType}>('{callableFullName}');" +
                    (useset ? $"\n    res.segment.entitySet('{this.EntitySetName}');" : "") +
                    (usename ? $"\n    options = Object.assign({{config: '{this.Options.Name}'}}, options || {{}});" : "") +
                    $"\n    return res.call({values}, '{responseType}', options) as Observable<{callableReturnType}>;" +
                    "\n  }";
            }
        }
        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationPropertyBinding> bindings)
        {
            var casts = new List<string>();
            foreach (var binding in bindings)
            {
                var isCollection = binding.NavigationProperty.IsCollection;
                var nav = binding.NavigationProperty;
                var navEntity = nav.EntityType;
                var bindingEntity = binding.EntityType;
                var propertyEntity = binding.PropertyType;

                var entity = (Program.Package as Angular.Package).FindEntity(navEntity.FullName);
                if (propertyEntity != null && bindingEntity.IsBaseOf(propertyEntity)) {
                    var castName = $"as{propertyEntity.Name}";
                    if (!casts.Contains(propertyEntity.FullName)) {
                        // Cast
                        entity = (Program.Package as Angular.Package).FindEntity(propertyEntity.FullName);
                        yield return $@"public {castName}(): {entity.Name}Model<{entity.Name}> {{
    return this._cast<any>('{propertyEntity.FullName}').asModel(this.toEntity()) as {entity.Name}Model<{entity.Name}>;
  }}";
                        casts.Add(propertyEntity.FullName);
                    }
                } else {
                    var returnType = isCollection ? $"ODataCollection<{entity.Name}, ODataModel<{entity.Name}>>" : $"ODataModel<{entity.Name}>";
                    var value = isCollection ? "asCollection()" : "asModel()";
                    var methodName = nav.Name.Substring(0, 1).ToLower() + nav.Name.Substring(1);

                    // Navigation
                    yield return $@"public {methodName}() {{
    return this._navigationProperty<{entity.Name}>('{binding.Path}').{value} as {returnType};
  }}";
                }
            }
        }
        public abstract object ToLiquid();
    }
}