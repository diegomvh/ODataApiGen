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
        public override string Name => Value.Name + ((Value is NavigationProperty || Value.Nullable) ? "?" : "");
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
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override string Name => this.EdmStructuredType.Name + "Model";
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
                        $"{typescriptType}";

                var responseType = callable.IsEdmReturnType ?
                        $"property" :
                    callable.ReturnsCollection ?
                        $"entities" :
                        $"entity";

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
                argumentWithType.Add(@"options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }");

                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{callableReturnType}> {{" +
                    $"\n    let body = Object.entries({{ {String.Join(", ", parameters.Select(p => p.Name))} }})" +
                    $"\n      .filter(pair => pair[1] !== null)" +
                    $"\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {{}});" +
                    $"\n    let res = this.{callable.Type.ToLower()}<{typescriptType}>(" +
                    $"'{callableFullName}'" +
                    $@"{(callable.Type != "Function" ? "" : ", body")}{(!String.IsNullOrEmpty(returnType) ? $", '{returnType}')" : ")")};
    return res.{(callable.Type == "Function" ? "get(" : "post(body, ")}{{
        headers: options && options.headers,
        params: options && options.params," +
        (!String.IsNullOrEmpty(returnType) ? $"\n        responseType: '{responseType}'," : "") + $@"
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
      }}).pipe(
      {(callable.IsEdmReturnType ?
        $"map(([entity,]) => entity)" :
            callable.ReturnsCollection ?
        $"map(([entity, annots]) => this._client.collectionForType<{typescriptType}>(entity, annots, res, '{returnType}'))" :
        $"map(([entity, annots]) => this._client.modelForType<{typescriptType}>(entity, annots, res, '{returnType}'))")}
     );
  }}";
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
        public override IEnumerable<Angular.StructuredProperty> Properties => this.EdmStructuredType.Properties
                .Union(this.EdmStructuredType.NavigationProperties)
                .Select(prop => {
                    var type = this.Dependencies.FirstOrDefault(dep => dep.Type == prop.Type);
                    return new Angular.ModelProperty(prop, type as AngularRenderable); 
                    });

        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityType = this.EntityType,
                Interface = new {
                    Name = this.Interface.Name
                }
            };
        }
    }
}