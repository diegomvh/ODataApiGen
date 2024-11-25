//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen ODataSingletonConfig
export const {{Name}} = {
  name: '{{SingletonName}}',
  type: '{{SingletonType}}',{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  service: {{Service.Name}}
};
//#endregion