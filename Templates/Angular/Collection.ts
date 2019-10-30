import { ODataCollection } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export class {{Name}} extends {% if Base != null %}{{Base.Name}}{% else %}ODataCollection<{{ModelName}}>{% endif %} {
  static model = {{ModelName}};
}
