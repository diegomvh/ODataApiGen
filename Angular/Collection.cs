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
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EdmStructuredType.Actions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EdmStructuredType.Functions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string> {
                    this.Model.EntityType
                };
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.EdmStructuredType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmStructuredType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                if (this.EdmStructuredType is EntityType)
                    list.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
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