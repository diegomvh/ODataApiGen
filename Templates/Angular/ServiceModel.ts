import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { 
  ODataClient,
  ODataService, 
  ODataEntity, 
  ODataEntities, 
  ODataProperty, 
  EntityKey,
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
export class {{Name}} extends ODataService<{{EntityName}}> {
  constructor(protected client: ODataClient) {
    super(client, '{{EntitySetName}}', '{{EntityType}}');
  }

  {{ModelName | methodcase}}(): {{ModelName}}<{{EntityName}}> {
    return super.model() as {{ModelName}}<{{EntityName}}>;
  }
  
  {{CollectionName | methodcase}}(): {{EntityName}}Collection<{{EntityName}}, {{EntityName}}Model<{{EntityName}}>> {
    return super.collection() as {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>>;
  }
}
