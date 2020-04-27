{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}} = {
  type: "{{EntityType}}",{% if Base != null %}
  base: "{{Base.EntityType}}",{% endif %}{% if EntitySetName != null %}
  set: { 
    name: "{{EntitySetName}}"
  },{% endif %}
  fields: {
    {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
};