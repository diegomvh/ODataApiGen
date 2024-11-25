//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen ODataEnumTypeConfig
export const {{Name}} = {
  name: '{{EdmEnumName}}',{% if Flags %}
  flags: true,{% endif %}
  members: {{EnumName}},{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}
  fields: {
    {% for member in Members %}{{member.Name}}: {{member.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
};
//#endregion