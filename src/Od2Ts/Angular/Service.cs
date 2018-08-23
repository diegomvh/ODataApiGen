using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular
{
    public class Service : Renderable, IHasImports
    {
        public Angular.Model Model {get; private set;}
        public string EdmEntityTypeName {get; set;}
        public Models.EntitySet EdmEntitySet { get; private set; }
        public bool UseReferences { get; set; } = false;
        public Service(Models.EntitySet type, bool useReferences)
        {
            EdmEntitySet = type;
            UseReferences = useReferences;
            EdmEntityTypeName = EdmEntitySet.EntityType.Split('.').Last();
        }

        public void SetModel(Angular.Model model) {
            this.Model = model;
        }
        
        public override string Render()
        {
            var actions = this.RenderCallables(this.EdmEntitySet.CustomActions);
            var functions = this.RenderCallables(this.EdmEntitySet.CustomFunctions);
            var relations = UseReferences ? 
                this.RenderReferences(this.Model.EdmStructuredType.NavigationProperties) :
                new List<string>();
            var imports = this.RenderImports(this);

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpClient }} from '@angular/common/http';
import {{ ODataEntityService, ODataContext, ODataQueryAbstract }} from 'angular-odata';

@Injectable()
export class {this.EdmEntitySet.Name} extends ODataEntityService<{EdmEntityTypeName}> {{
  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {{
    super(http, context, '{this.EdmEntitySet.EntitySetName}');
  }} 
  {String.Join("\n\n  ", actions)}
  {String.Join("\n\n  ", functions)}
  {String.Join("\n\n  ", relations)}
}}";
        }
        public IEnumerable<Import> Imports
        {
            get
            {
                var list = new List<Import>
                {
                    new Import(this.BuildUri(this.EdmEntitySet.EntityType))
                };
                list.AddRange(this.EdmEntitySet.CustomActions.SelectMany(a => this.BuildCallableImports(a)));
                list.AddRange(this.EdmEntitySet.CustomFunctions.SelectMany(a => this.BuildCallableImports(a)));
                return list;
            }
        }

        private IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
        {
            var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
            foreach (var name in names)
            {
                var callables = allCallables.Where(c => c.Name == name);
                var overload = callables.Count() > 1;
                var callable = callables.FirstOrDefault();
                var methodName = name[0].ToString().ToLower() + name.Substring(1);
                var returnTypeName = this.GetTypescriptType(callable.ReturnType);
                var returnType = returnTypeName + (callable.ReturnsCollection ? "[]" : "");
                var baseMethodName = callable.IsCollectionAction
                    ? $"customCollection{callable.Type}"
                    : $"custom{callable.Type}";

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

                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Promise<{returnType}> {{" +
                    $"\n    var body = Object.entries({{ {String.Join(", ", parameters.Select(p => p.Name))} }})" +
                    $"\n      .filter(pair => pair[1] !== null)" +
                    $"\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {{}});" +
                    $"\n    return this.{baseMethodName}(" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $"{boundArgument}, ") +
                    $"'{callable.NameSpace}.{callable.Name}'" +
                    (parameters.Any()? ", body)" : ")") + 
                    (callable.IsEdmReturnType ? 
                        $"\n      .then(resp => resp.toPropertyValue<{returnTypeName}>())\n  }}" : 
                    callable.ReturnsCollection ?
                        $"\n      .then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())\n  }}" : 
                        $"\n      .then(resp => resp.toEntity<{returnTypeName}>())\n  }}");
            }
        }

        private IEnumerable<string> RenderReferences(IEnumerable<Models.Property> properties) {
            foreach (var property in properties) {
                var type = this.GetTypescriptType(property.Type);
                var name = property.Name[0].ToString().ToUpper() + property.Name.Substring(1);
                var methodRelationName = property.Name;
                var methodCreateName = property.IsCollection ? $"add{type}To{name}" : $"set{type}As{name}";
                var methodDeleteName = property.IsCollection ? $"remove{type}From{name}" : $"unset{type}As{name}";
                var baseMethodCreateName = property.IsCollection ? $"createCollectionRef" : $"createRef";
                var baseMethodDeleteName = property.IsCollection ? $"deleteCollectionRef" : $"deleteRef";

                if (property.IsCollection) {
                    // Navigation
                    yield return $@"public {methodRelationName}(entity: {EdmEntityTypeName}) {{
    return this.navigation(entity, '{property.Name}');
  }}";
                } else {
                    // Property
                    yield return $@"public {methodRelationName}(entity: {EdmEntityTypeName}) {{
    return this.property(entity, '{property.Name}');
  }}";
                }
                // Link
                yield return $@"public {methodCreateName}(entity: {EdmEntityTypeName}, target: ODataQueryAbstract) {{
    return this.{baseMethodCreateName}(entity, '{property.Name}', target);
  }}";
                // Unlink
                yield return $@"public {methodDeleteName}(entity: {EdmEntityTypeName}, target: ODataQueryAbstract) {{
    return this.{baseMethodDeleteName}(entity, '{property.Name}', target);
  }}";
            }
        }

        public Uri Uri { get { return this.BuildUri(NameSpace, Name); } }
        public override string Name => this.EdmEntitySet.Name;
        public override string NameSpace => this.EdmEntitySet.NameSpace;
    }
}