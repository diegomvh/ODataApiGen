import { Container } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: "{{Name}}",
  services: [
    {% for config in ServiceConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
} as Container;