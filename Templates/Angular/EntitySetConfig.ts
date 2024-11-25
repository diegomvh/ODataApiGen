//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen ODataEntitySetConfig
export const {{Name}} = {
  name: '{{EntitySetName}}',
  entityType: '{{EntityType}}',{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  service: {{Service.Name}}
};
//#endregion