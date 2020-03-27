{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}} = {
  type: "{{EntityType}}",{% if Base != null %}
  base: "{{Base.EntityType}}",{% endif %}{% if ResourcePath != null %}
  set: "{{ResourcePath}}",{% endif %}
  fields: {
    {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
};