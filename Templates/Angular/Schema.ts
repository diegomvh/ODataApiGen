import { Schema } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  namespace: "{{Namespace}}",
  enums: [
    {% for config in EnumConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  entities: [
    {% for config in EntityConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  containers: [
    {% for container in Containers %}{{container.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
} as Schema;