using System.Collections.Generic;
using System.Linq;
using System.IO;
using ODataApiGen.Models;
using System;

namespace ODataApiGen.Angular
{
    public class ModelProperty : StructuredProperty 
    {
        public AngularRenderable Renderable {get; private set;}
        public ModelProperty(ODataApiGen.Models.Property prop, AngularRenderable type) : base(prop)
        {
            this.Renderable = type;
        }
        public override string Name {
            get {
                var required = !(Value is NavigationProperty || Value.Nullable);
                var annot = Value.Annotation("Org.OData.Core.V1.Computed");
                if (annot != null)
                    required = annot.Bool.ToLower() != "true";
                return Value.Name + (!required? "?" : "");
            }
        }
        public override string Type { get {
            var type = AngularRenderable.GetTypescriptType(Value.Type);
            if (this.Renderable is Enum) {
                return type;
            }
            if (Value.Collection)
                return type + (Value.IsEdmType ? "[]" : "Collection");
            else 
                return type + (Value.IsEdmType ? "" : "Model");
        }}
    }
    public class Model : Structured 
    {
        public Angular.Entity Interface { get; private set; }

        public Model(StructuredType type, Angular.Entity inter) : base(type) {
            this.Interface = inter;
            this.Dependencies.Add(inter);
        }
        public Angular.Collection Collection {get; private set;}

        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
            this.Dependencies.Add(collection);
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override string Name => this.EdmStructuredType.Name + "Model";
        public string BaseName => this.EdmStructuredType.Name + "BaseModel";
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EntityType
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.EdmStructuredType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmStructuredType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.EdmStructuredType is EntityType)
                    list.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                return list;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] { this.Name, this.BaseName };

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
                var callableReturnType = callable.IsEdmReturnType ?
                        $"{typescriptType}" :
                    callable.ReturnsCollection ?
                        $"{typescriptType}Collection" :
                    !String.IsNullOrEmpty(returnType) ?
                        $"{typescriptType}Model" : 
                        $"{typescriptType}";

                var responseType = callable.IsEdmReturnType ?
                        $"value" :
                    callable.ReturnsCollection ?
                        $"collection" :
                        $"model";

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
                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{callableReturnType}> {{" +
                    $"\n    {args}" +
                    $"\n    return this.call{callable.Type}<{typescriptType}>(" +
                    $"'{callableFullName}', args, '{responseType}', '{returnType}', options);" +
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
        public override IEnumerable<Angular.StructuredProperty> Properties {
            get {
                var props = this.EdmStructuredType.Properties.ToList();
                if (this.EdmStructuredType is EntityType) 
                    props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
                return props.Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    return new Angular.ModelProperty(prop, type as AngularRenderable); 
                });
            }
        } 
        public IEnumerable<string> Actions {
            get {
                var modelActions = this.EdmStructuredType.Actions.Where(a => !a.IsCollection);
                return modelActions.Count() > 0 ? this.RenderCallables(modelActions) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                var modelFunctions = this.EdmStructuredType.Functions.Where(a => !a.IsCollection);
                return modelFunctions.Count() > 0 ? this.RenderCallables(modelFunctions) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Navigations {
            get {
                if (this.EdmStructuredType is EntityType) {
                    var modelNavigations = (this.EdmStructuredType as EntityType).NavigationProperties.Where(nav => !nav.Collection);
                    return modelNavigations.Count() > 0 ? this.RenderReferences(modelNavigations) : Enumerable.Empty<string>();
                }
                return Enumerable.Empty<string>();
            }
        }
        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                BaseName = this.BaseName,
                EntityType = this.EntityType,
                Interface = new {
                    Name = this.Interface.Name
                }
            };
        }
    }
}