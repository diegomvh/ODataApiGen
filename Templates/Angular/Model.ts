import { ODataModel } from 'angular-odata';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export class {{Name}} extends {% if Base != null %}{{Base.Name}}{% else %}ODataModel{% endif %} {
  {% for property in Properties %}{{property.Name}}: {{property.Type}}{% unless forloop.last %};
  {% endunless %}{% endfor %}

  // Actions
  {% for action in Actions %}{{action}}
  {% endfor %}
  // Functions
  {% for func in Functions %}{{func}}
  {% endfor %}
}

export const {{SchemaName}} = {% if Base != null %}Object.assign({}, {{Base.SchemaName}}, {% endif %}{
  {% for field in SchemaFields %}{{field.Name}}: {{field.AsField}}{% unless forloop.last %},
  {% endunless %}{% endfor %}
}{% if Base != null %}){% endif %};