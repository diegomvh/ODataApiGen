import { ODataModel } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export class {{Name}} extends {% if Base != null %}{{Base.Name}}{% else %}ODataModel{% endif %} {
  {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %};
  {% endunless %}{% endfor %}
}

export const {{SchemaName}} = {
  {% if Base != null %}base: '{{Base.Type}}',{% endif %}
  keys: [ 
    {% for key in SchemaKeys %}{{key.AsKey}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  fields: [
    {% for field in SchemaFields %}{{field.AsField}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
};