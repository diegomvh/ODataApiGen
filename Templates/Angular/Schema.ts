{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}} = {% if Base != null %}Object.assign({}, {{Base.Name}}, {% endif %}{
  {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %},
  {% endunless %}{% endfor %}
}{% if Base != null %}){% endif %};