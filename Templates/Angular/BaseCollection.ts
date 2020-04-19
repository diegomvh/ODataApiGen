import { ODataModel, ODataCollection, HttpOptions } from 'angular-odata';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export abstract class {{Name}}<T, M extends ODataModel<T>> extends {% if Base != null %}{{Base.Name}}<T, M>{% else %}ODataCollection<T, M>{% endif %} {
  // Actions
  {% for action in Actions %}{{action}}
  {% endfor %}
  // Functions
  {% for func in Functions %}{{func}}
  {% endfor %}
}