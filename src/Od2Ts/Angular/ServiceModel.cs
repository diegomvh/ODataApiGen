using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ServiceModel : Service
    {
        public ServiceModel(EntitySet type, bool refe) : base(type, refe)
        {
        }
        public string GetSignature() {
            var signature = $"class {this.Name}";
            return $"{signature} extends ODataModelService";
        }

        public override string Render()
        {
            var imports = this.RenderImports();

            return $@"{String.Join("\n", imports)}
import {{ Injectable }} from '@angular/core';
import {{ HttpClient }} from '@angular/common/http';
import {{ ODataModelService, ODataContext, ODataRequest, ODataEntitySet }} from 'angular-odata';
import {{ Observable }} from 'rxjs';
import {{ map }} from 'rxjs/operators';

@Injectable()
export {this.GetSignature()} {{
  static modelType = '{this.EdmEntitySet.EntityType}';
  static collectionType = '{this.EdmEntitySet.EntityType}Collection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {{
    super(http, context, '{this.EdmEntitySet.EntitySetName}');
  }}
  
  model(attrs?: any): {this.Model.Name} {{
    return super.model(attrs) as {this.Model.Name};
  }}

  collection(attrs?: any): {this.Model.Name}Collection {{
    return super.collection(attrs) as {this.Model.Name}Collection;
  }}
}}";
        }
    }
}