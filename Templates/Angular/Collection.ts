import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region ODataApiGen Imports
import {
  ODataModel,
  ODataCollection,
  ODataOptions,
  ODataQueryArgumentsOptions
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export class {{Name}}<E extends {{Model.Entity.Name}}, M extends {{Model.Name}}<E>> extends {% if Base != null %}{{Base.Name}}<E, M>{% else %}ODataCollection<E, M>{% endif %} {
  //#region ODataApiGen Actions
  {% for action in Actions %}{{action}}
  {% endfor %}//#endregion
  //#region ODataApiGen Functions
  {% for func in Functions %}{{func}}
  {% endfor %}//#endregion
}