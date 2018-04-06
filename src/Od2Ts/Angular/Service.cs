using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Abstracts;
using Od2Ts.Interfaces;

namespace Od2Ts.Angular
{
    class Service : Renderable, IHasImports
    {
        public Models.EntitySet EdmEntitySet { get; private set; }
        public bool Interface { get; set; } = false;
        public Service(Models.EntitySet type)
        {
            EdmEntitySet = type;
        }
        public override string Render()
        {
            var actions = this.RenderCallables(this.EdmEntitySet.CustomActions);
            var functions = this.RenderCallables(this.EdmEntitySet.CustomFunctions);
            var entityTypeName = EdmEntitySet.EntityType.Split('.').Last();
            var imports = this.RenderImports(this);

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpClient }} from '@angular/common/http';
import {{ ODataService, ODataResponse }} from './../../odata';

@Injectable()
export class {this.EdmEntitySet.Name} extends ODataEntitySetService<{entityTypeName}> {{
  constructor(odata: ODataService, context: ODataContext) {{
    super(odata, context, '{this.EdmEntitySet.EntitySetName}');
  }} 
  {String.Join("\n\n  ", actions)}
  {String.Join("\n\n  ", functions)}
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
                return list;
            }
        }
        private IEnumerable<string> RenderCallables(IEnumerable<Callable> callables)
        {
            foreach (var callable in callables)
            {
                var returnTypeName = this.GetTypescriptType(callable.ReturnType);
                var returnType = returnTypeName + (callable.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = callable.IsCollectionAction
                    ? $"CustomCollection{callable.Type}"
                    : $"Custom{callable.Type}";

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

                yield return $@"public {callable.Name}({String.Join(", ", argumentWithType)}): Promise<{returnType}> {{
  return this.{baseExecFunctionName}('{callable.NameSpace}.{callable.Name}'" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $", {boundArgument}") +
                    (parameters.Any()? ", { " + String.Join(", ", parameters.Select(p => p.Name)) + " })" : ")") + 
                    (callable.IsEdmReturnType ? 
                        $"\n    .then(resp => resp.toPropertyValue<{returnTypeName}>())\n  }}" : 
                    callable.ReturnsCollection ?
                        $"\n    .then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())\n  }}" : 
                        $"\n    .then(resp => resp.toEntity<{returnTypeName}>())\n  }}");
            }
        }

        public Uri Uri { get { return this.BuildUri(NameSpace, Name); } }
        public override string Name => this.EdmEntitySet.Name;
        public override string NameSpace => this.EdmEntitySet.NameSpace;
    }
}