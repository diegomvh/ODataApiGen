using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ServiceEntity : Service
    {
        public ServiceEntity(EntitySet type, bool refe) : base(type, refe)
        {
        }
        protected string RenderKeyResolver() {
            var model = this.Model;
            var keys = model.EdmStructuredType.Keys.ToList(); 
            var baseModel = model.Base;
            while (baseModel != null) {
                keys.AddRange(model.Base.EdmStructuredType.Keys);
                baseModel = baseModel.Base;
            }
            if (keys.Count() == 0)
                return "";
            var parts = keys.Select(k => 
                !String.IsNullOrEmpty(k.Alias) ? 
                    $"{k.Alias}: entity.{k.Name.Replace('/','.')}" : 
                    $"{k.Name}: entity.{k.Name}");
            var key = keys.Count() > 1 ? 
                $"{{{String.Join(", ", parts)}}}" : 
                $"entity.{keys.First().Name}";

            return $@"protected resolveEntityKey(entity: Partial<{EdmEntityTypeName}>) {{
    return {key};
  }}";
        }

        public string GetSignature() {
            var signature = $"class {this.Name}";
            return $"{signature} extends ODataEntityService<{this.EdmEntityTypeName}>";
        }
        public override string Render()
        {
            var methods = new List<string>();
            methods.AddRange(this.RenderCallables(this.EdmEntitySet.CustomActions));
            methods.AddRange(this.RenderCallables(this.EdmEntitySet.CustomFunctions));
            if (References)
                methods.AddRange(this.RenderReferences(this.Model.EdmStructuredType.NavigationProperties));
            var imports = this.RenderImports();

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpHeaders, HttpParams }} from '@angular/common/http';
import {{ Observable }} from 'rxjs';
import {{ map }} from 'rxjs/operators';

import {{ ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet }} from 'angular-odata';

@Injectable()
export {this.GetSignature()} {{
  static set: string = '{this.EdmEntitySet.EntitySetName}';
  
  constructor(protected odata: ODataClient) {{
    super(odata);
  }}

  {RenderKeyResolver()}
  
  {String.Join("\n\n  ", methods)}
}}";
        }
    }
}