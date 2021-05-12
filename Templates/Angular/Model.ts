import { Model, ModelField, ODataModel, HttpCallableOptions, ODataCollection, HttpOptions, Duration } from 'angular-odata';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region ODataApi Imports
{% if HasGeoFields %}import { {% for p in GeoFields %}{{p.Type}}{% unless forloop.last %},{% endunless %}{% endfor %} } from 'geojson';
{% endif %}{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@Model()
export class {{Name}}<E extends {{Entity.Name}}> extends {% if Base != null %}{{Base.Name}}<E>{% else %}ODataModel<E>{% endif %} {
  //#region ODataApi Properties
  {% for field in Fields %}@ModelField()
  {{field.Name}}: {{field.Type}};
  {% endfor %}//#endregion
  //#region ODataApi Setters
  {% for field in SetterFields %}{{field.Setter}}{% endfor %}//#endregion
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