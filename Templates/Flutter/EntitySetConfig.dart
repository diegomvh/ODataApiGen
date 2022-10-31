//#region ODataApiGen ODataImports
import {
  EntitySetConfig
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen EntitySetConfig
export const {{Name}} = {
  name: '{{EntitySetName}}',
  entityType: '{{EntityType}}',{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  service: {{Service.Name}}
} as EntitySetConfig;
//#endregion