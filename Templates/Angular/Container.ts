import { EntityContainerConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApi EntityContainerConfig
export const {{Name}} = {
  name: "{{ContainerName}}",
  annotations: {{Annotations}},
  services: [
    {% for config in ServiceConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
} as EntityContainerConfig;
//#endregion