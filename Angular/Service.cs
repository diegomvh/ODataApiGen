using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class Service : AngularRenderable, ILiquidizable
    {
        public Angular.Entity Interface { get; private set; }
        public Angular.Model Model { get; private set; }
        public Angular.Collection Collection { get; private set; }
        public Service() { }

        public void SetInterface(Angular.Entity inter)
        {
            this.Interface = inter;
        }
        public void SetModel(Angular.Model model)
        {
            this.Model = model;
        }
        public void SetCollection(Angular.Collection collection)
        {
            this.Collection = collection;
        }
        public abstract string ResourcePath {get;}
        public abstract string EntityType {get;}
        public abstract string EntityName {get;}
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

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

                var baseMethodName = callable.IsCollection
                    ? $"collection{callable.Type}"
                    : $"{callable.Type.ToLower()}";

                if (!callable.IsBound) {
                    // Create function from odata client
                    baseMethodName = $"client.{baseMethodName}";
                }

                var returnType = AngularRenderable.GetType(callable.ReturnType);

                var typescriptType = AngularRenderable.GetTypescriptType(callable.ReturnType);
                var callableReturnType = callable.IsEdmReturnType ?
                        $"[{typescriptType}, ODataPropertyAnnotations]" :
                    callable.ReturnsCollection ?
                        $"[{typescriptType}[], ODataCollectionAnnotations]" :
                        $"[{typescriptType}, ODataEntityAnnotations]";

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
                var boundArgument = callable.IsBound && !callable.IsCollection?
                    callable.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)).ToLower() + "Id" :
                    "";

                if (callable.IsBound && !callable.IsCollection)
                    argumentWithType.Add($"{boundArgument}: any");

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
                    $"\n    var body = Object.entries({{ {String.Join(", ", parameters.Select(p => p.Name))} }})" +
                    $"\n      .filter(pair => pair[1] !== null)" +
                    $"\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {{}});" +
                    $"\n    return this.{baseMethodName}<{typescriptType}>(" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $"{boundArgument}, ") +
                    $"'{callableFullName}'" +
                    $@"{(callable.Type != "Function" ? "" : ", body")}{(!String.IsNullOrEmpty(returnType) ? $", '{returnType}')" : ")")}
      .{(callable.Type == "Function" ? "get(" : "post(body, ")}{{
        headers: options && options.headers,
        params: options && options.params," +
        (!String.IsNullOrEmpty(returnType) ? $"\n        responseType: '{responseType}'," : "") + $@"
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
      }});
  }}";
            }
        }

        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationProperty> navigations)
        {
            foreach (var nav in navigations)
            {
                var type = AngularRenderable.GetTypescriptType(nav.Type);
                var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);
                var methodRelationName = nav.Name;

                var methodCreateName = nav.Collection ? $"add{type}To{name}" : $"set{type}As{name}";
                var methodDeleteName = nav.Collection ? $"remove{type}From{name}" : $"unset{type}As{name}";

                var returnType = nav.Collection ? 
                    $"[{type}[], ODataCollectionAnnotations]" : 
                    $"[{type}, ODataEntityAnnotations]";

                // Navigation
                yield return $@"public {methodRelationName}(entity: {EntityName}, options?: {{
    headers?: HttpHeaders | {{[header: string]: string | string[]}},
    params?: HttpParams|{{[param: string]: string | string[]}},
    reportProgress?: boolean,
    withCredentials?: boolean
  }}): Observable<{returnType}> {{
    return this.navigationProperty<{type}>(entity, '{nav.Name}')
      .{(nav.Collection ? "collection" : "single")}(options);
  }}";
                // Link
                yield return $@"public {methodCreateName}<{type}>(entity: {EntityName}, target: ODataEntityResource<{type}>, etag?: string): Observable<any> {{
    return this.ref(entity, '{nav.Name}')
      .{(nav.Collection ? "add" : "set")}(target{(nav.Collection ? "" : ", {etag}")});
  }}";
                // Unlink
                yield return $@"public {methodDeleteName}<{type}>(entity: {EntityName}, target?: ODataEntityResource<{type}>, etag?: string): Observable<any> {{
    return this.ref(entity, '{nav.Name}')
      .remove({{etag, target}});
  }}";
            }
        }
        public object ToLiquid()
        {
            return new { Name = this.Name };
        }

    }
}