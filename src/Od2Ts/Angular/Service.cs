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
        public IEnumerable<Angular.Service> Services {get; private set;}
        public string EdmEntityTypeName {get; set;}
        public Models.EntitySet EdmEntitySet { get; private set; }
        public bool Interface { get; set; } = false;
        public Service(Models.EntitySet type)
        {
            EdmEntitySet = type;
            EdmEntityTypeName = EdmEntitySet.EntityType.Split('.').Last();
        }

        public void SetRelations(Angular.Model model, IEnumerable<Angular.Service> services) {
            this.Model = model;
            this.Services = services;
        }
        
        public override string Render()
        {
            var services = this.Services.Select(s => $"private {s.EdmEntitySet.EntitySetName}Service:{s.EdmEntitySet.Name}");
            var actions = this.RenderCallables(this.EdmEntitySet.CustomActions);
            var functions = this.RenderCallables(this.EdmEntitySet.CustomFunctions);
            var relations = this.RenderRelations(this.Model.EdmStructuredType.NavigationProperties);
            var imports = this.RenderImports(this);

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpClient }} from '@angular/common/http';
import {{ ODataService, ODataResponse }} from './../../odata';

@Injectable()
export class {this.EdmEntitySet.Name} extends ODataEntitySetService<{EdmEntityTypeName}> {{
  constructor(
    protected odata: ODataService, 
    protected context: ODataContext" + (services.Count() > 0? ",\n    " : "\n    ") +
    String.Join(",\n    ", services) +
  $@") {{
    super(odata, context, '{this.EdmEntitySet.EntitySetName}');
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
                    new Import(this.BuildUri(this.EdmEntitySet.EntityType)),
                    new Import(this.BuildUri("ODataContext")),
                    new Import(this.BuildUri("ODataEntitySetService"))
                };
                list.AddRange(this.EdmEntitySet.CustomActions.SelectMany(a => this.BuildCallableImports(a)));
                list.AddRange(this.EdmEntitySet.CustomFunctions.SelectMany(a => this.BuildCallableImports(a)));
                list.AddRange(this.Model.EdmStructuredType.NavigationProperties
                    .Select(a => a.Type)
                    .Where(a => a != this.Model.EdmStructuredType.NameSpace + "." + this.Model.EdmStructuredType.Name)
                    .ToList()
                    .Select(a => new Import(this.BuildUri(a))));
                list.AddRange(Services.Select(a => new Import(this.BuildUri(a.NameSpace, a.Name))));
                return list;
            }
        }

        private IEnumerable<string> RenderCallables(IEnumerable<Callable> callables)
        {
            foreach (var callable in callables)
            {
                var methodName = callable.Name[0].ToString().ToLower() + callable.Name.Substring(1);
                var returnTypeName = this.GetTypescriptType(callable.ReturnType);
                var returnType = returnTypeName + (callable.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = callable.IsCollectionAction
                    ? $"customCollection{callable.Type}"
                    : $"custom{callable.Type}";

                var parameters = callable.Parameters;
                var argumentWithType = new List<string>();
                var boundArgument = callable.IsCollectionAction ? 
                    "" : 
                    callable.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)).ToLower() + "Id";

                if (!callable.IsCollectionAction)
                    argumentWithType.Add($"{boundArgument}: any");

                argumentWithType.AddRange(parameters.Select(p => 
                    $"{p.Name}: {this.GetTypescriptType(p.Type)}" + (p.IsCollection? "[]" : "")
                ));

                yield return $@"public {methodName}({String.Join(", ", argumentWithType)}): Promise<{returnType}> {{
    return this.{baseExecFunctionName}(" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $"{boundArgument}, ") +
                    $"'{callable.NameSpace}.{callable.Name}'" +
                    (parameters.Any()? ", { " + String.Join(", ", parameters.Select(p => p.Name)) + " })" : ")") + 
                    (callable.IsEdmReturnType ? 
                        $"\n      .then(resp => resp.toPropertyValue<{returnTypeName}>())\n  }}" : 
                    callable.ReturnsCollection ?
                        $"\n      .then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())\n  }}" : 
                        $"\n      .then(resp => resp.toEntity<{returnTypeName}>())\n  }}");
            }
        }

        private IEnumerable<string> RenderRelations(IEnumerable<Models.Property> properties) {
            foreach (var property in properties) {
                var service = this.Services.FirstOrDefault(s => s.EdmEntitySet.EntityType == property.Type);
                if (service != null) {
                    var type = this.GetTypescriptType(property.Type);
                    var name = property.Name[0].ToString().ToUpper() + property.Name.Substring(1);
                    var methodCreateName = property.IsCollection ? $"add{type}To{name}" : $"set{type}As{name}";
                    var methodDeleteName = property.IsCollection ? $"remove{type}From{name}" : $"unset{type}As{name}";
                    yield return $@"{methodCreateName}(entity: {EdmEntityTypeName}, related: {type}) {{
    return this.createRef(entity, '{property.Name}', this.{service.EdmEntitySet.EntitySetName}Service.entity(related.id))
  }}";
                    yield return $@"{methodDeleteName}(entity: {EdmEntityTypeName}, related: {type}) {{
    return this.deleteRef(entity, '{property.Name}', this.{service.EdmEntitySet.EntitySetName}Service.entity(related.id))
  }}";
                }
            }
        }

        public Uri Uri { get { return this.BuildUri(NameSpace, Name); } }
        public override string Name => this.EdmEntitySet.Name;
        public override string NameSpace => this.EdmEntitySet.NameSpace;
    }
}