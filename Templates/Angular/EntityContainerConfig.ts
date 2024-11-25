//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen ODataEntityContainerConfig
export const {{Name}} = {
  name: '{{ContainerName}}',{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  entitySets: [
    {% for config in EntitySetConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  singletons: [
    {% for config in SingletonConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
};
//#endregion