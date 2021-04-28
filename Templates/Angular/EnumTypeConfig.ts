import { EnumTypeConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApi EnumTypeConfig
export const {{Name}} = {
  name: "{{EdmEnumName}}",{% if Flags %}
  flags: true,{% endif %}
  members: {{EnumName}},{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  fields: {
    {% for member in Members %}{{member.Name}}: {{member.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
} as EnumTypeConfig<{{EnumName}}>;
//#endregion