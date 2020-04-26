import { ODataModel, HttpOptions } from 'angular-odata';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export class {{Name}}<E extends {{Interface.Name}}> extends {% if Base != null %}{{Base.Model.Name}}<E>{% else %}ODataModel<E>{% endif %} {
  {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %};
  {% endunless %}{% endfor %}

  // Actions
  {% for action in Actions %}{{action}}
  {% endfor %}
  // Functions
  {% for func in Functions %}{{func}}
  {% endfor %}
  // Navigations
  {% for nav in Navigations %}{{nav}}
  {% endfor %}
}