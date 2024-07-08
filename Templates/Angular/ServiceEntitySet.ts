import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region ODataApiGen ODataImports
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
  ODataOptions,
  ODataQueryArgumentsOptions,
  ODataFunctionOptions,
  ODataActionOptions
} from 'angular-odata';//#endregion

//#region ODataApiGen Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@Injectable()
export class {{Name}} extends ODataEntitySetService<{{EntityName}}> {
  constructor(client: ODataClient) {
    super(client, '{{EntitySetName}}', '{{EntityType}}');
  }{% if HasModel %}
  //#region ODataApiGen Model
  {{ModelName | methodcase}}(entity?: Partial<{{EntityName}}>): {{ModelName}}<{{EntityName}}> {
    return this.entity().asModel<{{ModelName}}<{{EntityName}}>>(entity);
  }//#endregion{% endif %}{% if HasCollection %}
  //#region ODataApiGen Collection
  {{CollectionName | methodcase}}(entities?: Partial<{{EntityName}}>[]): {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>> {
    return this.entities().asCollection<{{ModelName}}<{{EntityName}}>, {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>>>(entities);
  }//#endregion{% endif %}
  //#region ODataApiGen Actions
  {% for action in Actions %}{{action}}
  {% endfor %}//#endregion
  //#region ODataApiGen Functions
  {% for func in Functions %}{{func}}
  {% endfor %}//#endregion
  //#region ODataApiGen Navigations
  {% for nav in Navigations %}{{nav}}
  {% endfor %}//#endregion
}
