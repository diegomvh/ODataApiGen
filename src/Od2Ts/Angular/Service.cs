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
        public Angular.Model Model {get; private set;}
        public Angular.Collection Collection {get; private set;}
        public string EdmEntityTypeName {get; set;}
        public Models.EntitySet EdmEntitySet { get; private set; }
        public bool References { get; set; } = false;
        public Service(Models.EntitySet type, bool refe)
        {
            EdmEntitySet = type;
            References = refe;
            EdmEntityTypeName = EdmEntitySet.EntityType.Split('.').Last();
        }

        public void SetModel(Angular.Model model) {
            this.Model = model;
        }
        public void SetCollection(Angular.Collection collection) {
            this.Collection = collection;
        }

        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var parameters = new List<Models.Parameter>();
                foreach (var cal in this.EdmEntitySet.CustomActions)
                    parameters.AddRange(cal.Parameters);
                foreach (var cal in this.EdmEntitySet.CustomFunctions)
                    parameters.AddRange(cal.Parameters);

                var list = new List<string> {
                    this.EdmEntitySet.EntityType
                };
                //list.AddRange(parameters.GroupBy(p => p.Name).Select(g => g.First()).ToList().SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmEntitySet.CustomActions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmEntitySet.CustomFunctions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.Model.EdmStructuredType.NavigationProperties.Select(a => a.Type));
                return list;
            }
        }

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
                var returnTypeName = this.GetTypescriptType(callable.ReturnType);
                var returnType = callable.ReturnsCollection ? $"ODataEntitySet<{returnTypeName}>" : $"{returnTypeName}"; 
                var baseMethodName = callable.IsCollectionAction
                    ? $"customCollection{callable.Type}"
                    : $"custom{callable.Type}";

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
                    $"{p.Name}: {this.GetTypescriptType(p.Type)}" + 
                    (p.IsCollection? "[]" : "") + 
                    (optionals.Contains(p)? " = null" : "")
                ));
                argumentWithType.Add(@"options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }");

                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{returnType}> {{" +
                    $"\n    var body = Object.entries({{ {String.Join(", ", parameters.Select(p => p.Name))} }})" +
                    $"\n      .filter(pair => pair[1] !== null)" +
                    $"\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {{}});" +
                    $"\n    return this.{baseMethodName}<{returnTypeName}>(" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $"{boundArgument}, ") +
                    $"'{callable.NameSpace}.{callable.Name}'" +
                    $@",body, {{
      headers: options && options.headers,
      params: options && options.params,
      responseType: '{responseType}',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    }});
  }}";
            }
        }

        protected IEnumerable<string> RenderReferences(IEnumerable<Models.NavigationProperty> navigations) {
            foreach (var nav in navigations) {
                var type = this.GetTypescriptType(nav.Type);
                var name = nav.Name[0].ToString().ToUpper() + nav.Name.Substring(1);
                var methodRelationName = nav.Name;

                var methodCreateName = nav.IsCollection ? $"add{type}To{name}" : $"set{type}As{name}";
                var methodDeleteName = nav.IsCollection ? $"remove{type}From{name}" : $"unset{type}As{name}";

                var returnType = (nav.IsCollection) ? $"ODataEntitySet<{type}>" : $"{type}"; 

                // Navigation
                yield return $@"public {methodRelationName}(entity: {EdmEntityTypeName}, options?: {{
    headers?: HttpHeaders | {{[header: string]: string | string[]}},
    params?: HttpParams|{{[param: string]: string | string[]}},
    reportProgress?: boolean,
    withCredentials?: boolean
  }}): Observable<{returnType}> {{
    return this.navigationProperty<{type}>(entity, '{nav.Name}', {{
        headers: options && options.headers,
        params: options && options.params,
        responseType: {(nav.IsCollection? "'entityset'" : "'entity'")},
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    }});
  }}";
                // Link
                yield return $@"public {methodCreateName}<{type}>(entity: {EdmEntityTypeName}, target: ODataEntityRequest<{type}>, options?: {{
    headers?: HttpHeaders | {{[header: string]: string | string[]}},
    params?: HttpParams|{{[param: string]: string | string[]}},
    reportProgress?: boolean,
    withCredentials?: boolean
  }}) {{
    return this.createRef(entity, '{nav.Name}', target, {{
        headers: options && options.headers,
        params: options && options.params,
        responseType: {(nav.IsCollection? "'entityset'" : "'entity'")},
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    }});
  }}";
                // Unlink
                yield return $@"public {methodDeleteName}<{type}>(entity: {EdmEntityTypeName}, target: ODataEntityRequest<{type}>, options?: {{
    headers?: HttpHeaders | {{[header: string]: string | string[]}},
    params?: HttpParams|{{[param: string]: string | string[]}},
    reportProgress?: boolean,
    withCredentials?: boolean
  }}) {{
    return this.deleteRef(entity, '{nav.Name}', target, {{
        headers: options && options.headers,
        params: options && options.params,
        responseType: {(nav.IsCollection? "'entityset'" : "'entity'")},
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    }});
  }}";
            }
        }

        public object ToLiquid()
        {
            return new {Name=this.Name};
        }

        public override string Name => this.EdmEntitySet.Name + "Service";
        public override string NameSpace => this.EdmEntitySet.NameSpace;
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public override string Directory => this.NameSpace.Replace('.', Path.DirectorySeparatorChar);
    }
}