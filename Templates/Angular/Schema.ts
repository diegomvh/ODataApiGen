import { Schema } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  namespace: "{{Namespace}}",
  enums: {
    {% for config in EnumConfigs %}'{{config.EnumName}}': {{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  entities: {
    {% for config in EntityConfigs %}'{{config.EntityName}}': {{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  containers: {
    {% for container in Containers %}'{{container.Name}}': {{container.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}}
} as Schema;