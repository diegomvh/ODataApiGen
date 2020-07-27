import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { 
  ODataClient,
  ODataEntityService, 
  ODataEntityAnnotations, 
  ODataEntitiesAnnotations, 
  ODataPropertyAnnotations, 
  EntityKey,
  ODataEntityResource,
  ODataEntitySetResource,
  ODataNavigationPropertyResource,
  HttpOptions
} from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@Injectable()
export class {{Name}} {
 
  constructor(protected client: ODataClient) { }

  //#region ODataApi Actions
  {% for action in Actions %}{{action}}
  {% endfor %}//#endregion
  //#region ODataApi Functions
  {% for func in Functions %}{{func}}
  {% endfor %}//#endregion
}