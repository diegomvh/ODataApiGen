import { EnumTypeConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: "{{EdmEnumName}}",{% if Flags %}
  flags: true,{% endif %}
  enum: {{EnumName}},
  annotations: {{Annotations}},
  members: {
    {% for member in Members %}{{member.Name}}: {{member.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
} as EnumTypeConfig<{{EnumName}}>;