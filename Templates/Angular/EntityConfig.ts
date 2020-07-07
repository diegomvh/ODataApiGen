import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: "{{EntityName}}",{% if Base != null %}
  base: "{{Base.EntityType}}",{% endif %}{% if OpenType %}
  open: true,{% endif %}{% if Model != null %}
  model: {{Model.Name}},{% endif %}{% if Collection != null %}
  collection: {{Collection.Name}},{% endif %}
  annotations: {{Annotations}},
  fields: {
    {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
} as EntityConfig<{{EntityName}}>;