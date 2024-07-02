//#region ODataApiGen ODataImports
import {
  SingletonConfig
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen SingletonConfig
export const {{Name}} = {
  name: '{{SingletonName}}',
  type: '{{SingletonType}}',{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  service: {{Service.Name}}
} as SingletonConfig;
//#endregion