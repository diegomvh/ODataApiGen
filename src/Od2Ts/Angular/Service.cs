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
            var actions = this.RenderCustomActions();
            var functions = this.RenderCustomFunctions();
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
                {String.Join("\n", actions)}
                {String.Join("\n", functions)}
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

        private IEnumerable<string> RenderCustomActions()
        {
            foreach (var action in this.EdmEntitySet.CustomActions)
            {
                var returnTypeName = this.GetTypescriptType(action.ReturnType);
                var returnType = returnTypeName + (action.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = action.IsCollectionAction
                    ? "CustomCollectionAction"
                    : "CustomAction";

                var parameters = action.Parameters;
                var argumentWithType = new List<string>();
                var boundArgument = action.IsCollectionAction ? "" : action.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)) + "Id";

                if (!action.IsCollectionAction)
                    argumentWithType.Add($"{boundArgument}: any");

                argumentWithType.AddRange(parameters.Select(p => 
                    $"{p.Name}: {this.GetTypescriptType(p.Type)}"
                ));

                yield return $@"public {action.Name}({String.Join(", ", argumentWithType)}): Promise<{returnType}> {{
                    return this.{baseExecFunctionName}('{action.NameSpace}.{action.Name}'" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $", {boundArgument}") +
                    (parameters.Any()? ", { " + String.Join(", ", parameters.Select(p => p.Name)) + " })" : ")") + 
                    (action.IsEdmReturnType ? 
                        $".then(resp => resp.toPropertyValue<{returnTypeName}>())" : 
                    action.ReturnsCollection ?
                        $".then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())" : 
                        $".then(resp => resp.toEntity<{returnTypeName}>())");
            }
        }
        private IEnumerable<string> RenderCustomFunctions()
        {
            foreach (var function in this.EdmEntitySet.CustomFunctions)
            {
                var returnTypeName = this.GetTypescriptType(function.ReturnType);
                var returnType = returnTypeName + (function.ReturnsCollection ? "[]" : "");
                var baseExecFunctionName = function.IsCollectionAction
                    ? "CustomCollectionFunction"
                    : "CustomFunction";

                var parameters = function.Parameters;
                var argumentWithType = new List<string>();
                var boundArgument = function.IsCollectionAction ? "" : function.BindingParameter.Split('.').Last(a => !string.IsNullOrWhiteSpace(a)) + "Id";

                if (!function.IsCollectionAction)
                    argumentWithType.Add($"{boundArgument}: any");

                argumentWithType.AddRange(parameters.Select(p => 
                    $"{p.Name}: {this.GetTypescriptType(p.Type)}"
                ));

                yield return $@"public {function.Name}({String.Join(", ", argumentWithType)}): Promise<{returnType}> {{
                    return this.{baseExecFunctionName}('{function.NameSpace}.{function.Name}'" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $", {boundArgument}") +
                    (parameters.Any()? ", { " + String.Join(", ", parameters.Select(p => p.Name)) + " })" : ")") + 
                    (function.IsEdmReturnType ? 
                        $".then(resp => resp.toPropertyValue<{returnTypeName}>())" : 
                    function.ReturnsCollection ?
                        $".then(resp => resp.toEntitySet<{returnTypeName}>().getEntities())" : 
                        $".then(resp => resp.toEntity<{returnTypeName}>())");
            }
        }

        public Uri Uri { get { return this.BuildUri(NameSpace, Name); } }
        public override string Name => this.EdmEntitySet.Name;
        public override string NameSpace => this.EdmEntitySet.NameSpace;
    }
}