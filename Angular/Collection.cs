using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class Collection : AngularRenderable
    {
        public StructuredType EdmStructuredType { get; private set; }
        public Angular.Model Model { get; private set; }
        public Angular.Service Service {get; private set;}

        public Collection(StructuredType type, Angular.Model model)
        {
            EdmStructuredType = type;
            this.Model = model;
            this.Dependencies.Add(model);
            model.SetCollection(this);
        }
        
        public void SetService(Service service)
        {
            this.Service = service;
        }
        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.Model.EntityType
                };
                return list;
            }
        }
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public override IEnumerable<Import> Imports => GetImportRecords();
        public override string Name => this.EdmStructuredType.Name + "Collection";
        public string EntityType => this.EdmStructuredType.FullName;
        public override string NameSpace => this.EdmStructuredType.Namespace;
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        public string ModelName => this.Model.Name;
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".collection";
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
                var collectionActions = this.EdmStructuredType.Actions.Where(a => a.IsCollection);
                return collectionActions.Count() > 0 ? this.RenderCallables(collectionActions) : Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Functions {
            get {
                var collectionFunctions = this.EdmStructuredType.Functions.Where(a => a.IsCollection);
                return collectionFunctions.Count() > 0 ? this.RenderCallables(collectionFunctions) : Enumerable.Empty<string>();
            }
        }
    }
}