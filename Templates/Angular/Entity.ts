{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export interface {{Name}}{% if Base != null %} extends {{Base.Name}}{% endif %} {
  {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %};
  {% endunless %}{% endfor %}
}

export const {{SchemaName}} = {% if Base != null %}Object.assign({}, {{Base.SchemaName}}, {% endif %}{
  {% for field in SchemaFields %}{{field.Name}}: {{field.AsField}}{% unless forloop.last %},
  {% endunless %}{% endfor %}
}{% if Base != null %}){% endif %};