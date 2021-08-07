import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region AngularOData Imports
import { 
  ODataModel, 
  ODataCollection, 
  HttpOptions, 
  HttpQueryOptions
} from 'angular-odata';//#endregion

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export class {{Name}}<E extends {{Model.Entity.Name}}, M extends {{Model.Name}}<E>> extends {% if Base != null %}{{Base.Name}}<E, M>{% else %}ODataCollection<E, M>{% endif %} {
  //#region ODataApi Actions
  {% for action in Actions %}{{action}}
  {% endfor %}//#endregion
  //#region ODataApi Functions
  {% for func in Functions %}{{func}}
  {% endfor %}//#endregion
}