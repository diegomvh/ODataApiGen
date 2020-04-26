import { ODataModel, ODataCollection, HttpOptions } from 'angular-odata';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export class {{Name}}<E extends {{BaseModel.Interface.Name}}, M extends {{BaseModel.Name}}<E>> extends {% if Base != null %}{{Base.Collection.Name}}<E, M>{% else %}ODataCollection<E, M>{% endif %} {
  // Actions
  {% for action in Actions %}{{action}}
  {% endfor %}
  // Functions
  {% for func in Functions %}{{func}}
  {% endfor %}
}