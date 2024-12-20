//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApiGen ODataStrucutredTypeConfig
export const {{Name}} = {
  name: '{{EdmEntityName}}',{% if Base != null %}
  base: '{{Base.EntityType}}',{% endif %}{% if OpenType %}
  open: true,{% endif %}{% if Model != null %}
  model: {{Model.Name}},{% endif %}{% if Collection != null %}
  collection: {{Collection.Name}},{% endif %}{% if HasAnnotations %}
  annotations: {{Annotations}},{% endif %}{% if HasKey %}
  keys: [{% for key in Keys %}{{key.Value}}{% unless forloop.last %},{% endunless %}{% endfor %}],{% endif %}
  fields: {
    {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
};
//#endregion