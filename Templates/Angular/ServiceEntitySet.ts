import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { 
  ODataClient,
  ODataEntitySetService, 
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
  HttpOptions
} from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@Injectable()
export class {{Name}} extends ODataEntitySetService<{{EntityName}}> {
  constructor(protected client: ODataClient) {
    super(client, '{{EntitySetName}}', '{{EntityType}}');
  }

  {% if HasModel %}//#region ODataApi Model
  {{ModelName | methodcase}}(attrs?: Partial<{{EntityName}}>): {{ModelName}}<{{EntityName}}> {
    return this.entity().asModel(attrs || {}) as {{ModelName}}<{{EntityName}}>;
  }
  //#endregion{% endif %}
  {% if HasCollection %}//#region ODataApi Collection
  {{CollectionName | methodcase}}(models?: Partial<{{EntityName}}>[]): {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>> {
    return this.entities().asCollection(models || []) as {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>>;
  }
  //#endregion{% endif %}
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
