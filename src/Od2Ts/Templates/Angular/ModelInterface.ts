import { EntitySchema } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export interface {{Name}}{% if Base != null %} extends {{Base.Name}}{% endif %} {
  {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %};
  {% endunless %}{% endfor %}
}

export const {{SchemaName}} = {% if Base == null %}EntitySchema.create<{{Name}}>({ {% else %}{{Base.SchemaName}}.extend<{{Name}}>({ {% endif %}
  keys: [
    {% for key in SchemaKeys %}{{key}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  fields: [
    {% for field in SchemaFields %}{{field}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
});