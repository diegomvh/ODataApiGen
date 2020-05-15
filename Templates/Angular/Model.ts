import { ODataModel, HttpOptions } from 'angular-odata';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export class {{Name}}<E extends {{Entity.Name}}> extends {% if Base != null %}{{Base.Name}}<E>{% else %}ODataModel<E>{% endif %} {
  //#region ODataApi Properties
  {% for property in Properties %}{{property.Name}}: {{property.Type}};
  {% endfor %}//#endregion
  //#region ODataApi Actions
  {% for action in Actions %}{{action}}
  {% endfor %}//#endregion
  //#region ODataApi Functions
  {% for func in Functions %}{{func}}
  {% endfor %}//#endregion
  //#region ODataApi Navigations
  {% for nav in Navigations %}{{nav}}
  {% endfor %}//#endregion
}