using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public abstract class Service : AngularRenderable, ILiquidizable
    {
        public Angular.Entity Entity { get; private set; }
        public Angular.Model Model { get; private set; }
        public Angular.Collection Collection { get; private set; }
        public string EdmEntityTypeName { get; set; }
        public Models.EntitySet EdmEntitySet { get; private set; }
        public Service(Models.EntitySet type)
        {
            EdmEntitySet = type;
            EdmEntityTypeName = EdmEntitySet.EntityType.Split('.').Last();
        }

        public void SetEntity(Angular.Entity entity)
        {
            this.Entity = entity;
        }
        public void SetModel(Angular.Model model)
        {
            this.Model = model;
        }
        public void SetCollection(Angular.Collection collection)
        {
            this.Collection = collection;
        }

        public override string Name => this.EdmEntitySet.Name + "Service";
        public override string NameSpace => this.EdmEntitySet.NameSpace;
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
        // Imports
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EdmEntitySet.Actions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EdmEntitySet.Functions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string> {
                    this.EdmEntitySet.EntityType
                };
                list.AddRange(parameters.Select(p => p.Type));
                list.AddRange(this.EdmEntitySet.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmEntitySet.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.Entity != null)
                {
                    list.AddRange(this.Entity.EdmStructuredType.Properties.Select(a => a.Type));
                    list.AddRange(this.Entity.EdmStructuredType.NavigationProperties.Select(a => a.Type));
                }
                if (this.Model != null)
                {
                    list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
                    list.AddRange(this.Model.EdmStructuredType.NavigationProperties.Select(a => a.Type));
                }
                return list;
            }
        }

        // Exports
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };
        public string EntitySet => this.EdmEntitySet.EntitySetName;

        protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
        {
            var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
            foreach (var name in names)
            {
                var callables = allCallables.Where(c => c.Name == name);
                var overload = callables.Count() > 1;
                var callable = callables.FirstOrDefault();
                var methodName = name[0].ToString().ToLower() + name.Substring(1);
                var returnType = AngularRenderable.GetType(callable.ReturnType);
                var typescriptType = AngularRenderable.GetTypescriptType(callable.ReturnType);

                var callableReturnType = callable.IsEdmReturnType ?
                        $"ODataProperty<{typescriptType}>" :
                    callable.ReturnsCollection ?
                        $"ODataEntitySet<{typescriptType}>" :
                        $"{typescriptType}";

                var baseMethodName = callable.IsCollectionAction
                    ? $"collection{callable.Type}"
                    : $"{callable.Type.ToLower()}";

                var responseType = callable.IsEdmReturnType ?
                        $"property" :
                    callable.ReturnsCollection ?
                        $"entityset" :
                        $"entity";

                var parameters = new List<Models.Parameter>();
                foreach (var cal in callables)
                    parameters.AddRange(cal.Parameters);
                var optionals = parameters.Where(p =>
                    !callables.All(c => c.Parameters.Contains(p))).ToList();
                parameters = parameters.GroupBy(p => p.Name).Select(g => g.First()).ToList();

                var argumentWithType = new List<string>();
                var boundArgument = callable.IsCollectionAction ?
                    "" :
                    callable.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)).ToLower() + "Id";

                if (!callable.IsCollectionAction)
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
                    $"'{callable.NameSpace}.{callable.Name}'" +
                    $@", {(callable.Type != "Function" ? "" : "body, ")}'{returnType}')
                    .{(callable.Type == "Function" ? "get(" : "post(body, ")}{{
      headers: options && options.headers,
      params: options && options.params,
      responseType: '{responseType}',
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

                var methodCreateName = nav.IsCollection ? $"add{type}To{name}" : $"set{type}As{name}";
                var methodDeleteName = nav.IsCollection ? $"remove{type}From{name}" : $"unset{type}As{name}";

                var returnType = (nav.IsCollection) ? $"ODataCollection<{type}>" : $"{type}";

                // Navigation
                yield return $@"public {methodRelationName}(entity: {EdmEntityTypeName}, options?: {{
    headers?: HttpHeaders | {{[header: string]: string | string[]}},
    params?: HttpParams|{{[param: string]: string | string[]}},
    reportProgress?: boolean,
    withCredentials?: boolean
  }}): Observable<{returnType}> {{
    return this.navigationProperty<{type}>(entity, '{nav.Name}')
      .{(nav.IsCollection ? "collection" : "single")}(options);
  }}";
                // Link
                yield return $@"public {methodCreateName}<{type}>(entity: {EdmEntityTypeName}, target: ODataEntityResource<{type}>): Observable<any> {{
    return this.ref(entity, '{nav.Name}')
      .{(nav.IsCollection ? "add" : "set")}(target{(nav.IsCollection ? "" : ", {etag: this.client.resolveEtag(entity)}")});
  }}";
                // Unlink
                yield return $@"public {methodDeleteName}<{type}>(entity: {EdmEntityTypeName}, target?: ODataEntityResource<{type}>): Observable<any> {{
    return this.ref(entity, '{nav.Name}')
      .remove({{etag: this.client.resolveEtag(entity), target}});
  }}";
            }
        }

        public object ToLiquid()
        {
            return new { Name = this.Name };
        }

    }
}