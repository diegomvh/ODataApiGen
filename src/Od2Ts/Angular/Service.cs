using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public abstract class Service : AngularRenderable
    {
        public Angular.Model Model {get; private set;}
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
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EdmEntitySet.EntityType
                };
                list.AddRange(this.EdmEntitySet.CustomActions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmEntitySet.CustomFunctions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.Model.EdmStructuredType.NavigationProperties.Select(a => a.Type));
                return list;
            }
        }

        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        protected string RenderKeyResolver() {
            var model = this.Model;
            var keys = new List<string>(model.EdmStructuredType.KeyNames); 
            while (model.Base != null) {
                model = model.Base;
                keys.AddRange(model.EdmStructuredType.KeyNames);
            }
            if (keys.Count() == 0)
                return "";
            var parts = keys.Select(name => $"{name}: entity.{name}");
            var key = keys.Count() > 1 ? $"{{{String.Join(", ", parts)}}}" : $"entity.{keys.First()}";

            return $@"protected resolveEntityKey(entity: Partial<{EdmEntityTypeName}>) {{
    return {key};
  }}";
        }

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
                argumentWithType.Add("options?");

                yield return $"public {methodName}({String.Join(", ", argumentWithType)}): Observable<{returnType}> {{" +
                    $"\n    var body = Object.entries({{ {String.Join(", ", parameters.Select(p => p.Name))} }})" +
                    $"\n      .filter(pair => pair[1] !== null)" +
                    $"\n      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {{}});" +
                    $"\n    return this.{baseMethodName}(" +
                    (String.IsNullOrWhiteSpace(boundArgument) ? boundArgument : $"{boundArgument}, ") +
                    $"'{callable.NameSpace}.{callable.Name}'" +
                    (parameters.Any()? ", body, options)" : ", options)") + 
                    (callable.IsEdmReturnType ? 
                        $"\n      .pipe(map(resp => resp.toPropertyValue<{returnTypeName}>()))\n  }}" : 
                    callable.ReturnsCollection ?
                        $"\n      .pipe(map(resp => resp.toEntitySet<{returnTypeName}>().getEntities()))\n  }}" : 
                        $"\n      .pipe(map(resp => resp.toEntity<{returnTypeName}>()))\n  }}");
            }
        }

        protected IEnumerable<string> RenderReferences(IEnumerable<Models.Property> properties) {
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
                    yield return $@"public {methodRelationName}(entity: {EdmEntityTypeName}, options?): Observable<EntitySet<{this.GetTypescriptType(property.Type)}>> {{
    return this.navigationProperty(entity, '{property.Name}', options);
  }}";
                } else {
                    // Property
                    yield return $@"public {methodRelationName}(entity: {EdmEntityTypeName}, options?): Observable<EntitySet<{this.GetTypescriptType(property.Type)}>> {{
    return this.property(entity, '{property.Name}', options);
  }}";
                }
                // Link
                yield return $@"public {methodCreateName}(entity: {EdmEntityTypeName}, target: ODataQueryBase, options?) {{
    return this.{baseMethodCreateName}(entity, '{property.Name}', target, options);
  }}";
                // Unlink
                yield return $@"public {methodDeleteName}(entity: {EdmEntityTypeName}, target: ODataQueryBase, options?) {{
    return this.{baseMethodDeleteName}(entity, '{property.Name}', target, options);
  }}";
            }
        }
        public override string Name => this.EdmEntitySet.Name + "Service";
        public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
        public override string Directory => this.EdmEntitySet.NameSpace.Replace('.', Path.DirectorySeparatorChar);
    }

    public class ServiceEntity : Service
    {
        public ServiceEntity(EntitySet type, bool refe) : base(type, refe)
        {
        }

        public string GetSignature() {
            var signature = $"class {this.Name}";
            return $"{signature} extends ODataEntityService<{EdmEntityTypeName}>";
        }
        public override string Render()
        {
            var methods = new List<string>();
            methods.AddRange(this.RenderCallables(this.EdmEntitySet.CustomActions));
            methods.AddRange(this.RenderCallables(this.EdmEntitySet.CustomFunctions));
            if (References)
                methods.AddRange( this.RenderReferences(this.Model.EdmStructuredType.NavigationProperties));
            var imports = this.RenderImports();

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpClient }} from '@angular/common/http';
import {{ ODataEntityService, ODataModelService, ODataContext, ODataQueryBase, EntitySet }} from 'angular-odata';
import {{ Observable }} from 'rxjs';
import {{ map }} from 'rxjs/operators';

@Injectable()
export {this.GetSignature()} {{
  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {{
    super(http, context, '{this.EdmEntitySet.EntitySetName}');
  }}
  
  {RenderKeyResolver()}
  
  {String.Join("\n\n  ", methods)}
}}";
        }
    }

    public class ServiceModel : Service
    {
        public ServiceModel(EntitySet type, bool refe) : base(type, refe)
        {
        }

        public string GetSignature() {
            var signature = $"class {this.Name}";
            return $"{signature} extends ODataModelService<{EdmEntityTypeName}, {EdmEntityTypeName}Collection>";
        }

        public override string Render()
        {
            var methods = new List<string>();
            methods.AddRange(this.RenderCallables(this.EdmEntitySet.CustomActions));
            methods.AddRange(this.RenderCallables(this.EdmEntitySet.CustomFunctions));
            if (References)
                methods.AddRange( this.RenderReferences(this.Model.EdmStructuredType.NavigationProperties));
            var imports = this.RenderImports();

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpClient }} from '@angular/common/http';
import {{ ODataEntityService, ODataModelService, ODataContext, ODataQueryBase, EntitySet }} from 'angular-odata';
import {{ Observable }} from 'rxjs';
import {{ map }} from 'rxjs/operators';

@Injectable()
export {this.GetSignature()} {{
  static Model = {this.EdmEntityTypeName};
  static Collection = {this.EdmEntityTypeName}Collection;

  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {{
    super(http, context, '{this.EdmEntitySet.EntitySetName}');
  }}
  
  {RenderKeyResolver()}
  
  {String.Join("\n\n  ", methods)}
}}";
        }
    }
}