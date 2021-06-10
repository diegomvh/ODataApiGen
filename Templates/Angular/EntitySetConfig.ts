//#region AngularOData Imports
import { 
  EntitySetConfig 
} from 'angular-odata';//#endregion

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApi EntitySetConfig
export const {{Name}} = {
  name: "{{EntitySetName}}",
  entityType: "{{EntityType}}",{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  service: {{Service.Name}}
} as EntitySetConfig;
//#endregion