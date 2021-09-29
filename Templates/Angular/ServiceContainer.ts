import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region ODataApiGen ODataImports
import {
  ODataClient,
  ODataEntity,
  ODataEntities,
  ODataProperty,
  EntityKey,
  Duration,
  ODataEntityResource,
  ODataEntitySetResource,
  ODataNavigationPropertyResource,
  ODataActionResource,
  ODataFunctionResource,
  ODataOptions,
  ODataQueryArgumentsOptions,
  ODataBaseService
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@Injectable()
export class {{Name}} extends ODataBaseService {

  constructor(protected client: ODataClient) {
    super(client, '{{EntitySetName}}', '{{ApiName}}');
  }

  //#region ODataApiGen Actions
  {% for action in Actions %}{{action}}
  {% endfor %}//#endregion
  //#region ODataApiGen Functions
  {% for func in Functions %}{{func}}
  {% endfor %}//#endregion
}