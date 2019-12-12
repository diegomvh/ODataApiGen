import { ODataModelCollection } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export class {{Name}} extends {% if Base != null %}{{Base.Name}}{% else %}ODataModelCollection<{{ModelName}}>{% endif %} {
  // Actions
  {% for action in Actions %}{{action}}
  {% endfor %}
  // Functions
  {% for func in Functions %}{{func}}
  {% endfor %}
}
