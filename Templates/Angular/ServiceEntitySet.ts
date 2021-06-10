import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

//#region AngularOData Imports
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
  Expand, 
  Select,
  HttpOptions,
  HttpActionOptions,
  HttpFunctionOptions,
  HttpNavigationPropertyOptions
} from 'angular-odata';//#endregion

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

@Injectable()
export class {{Name}} extends ODataEntitySetService<{{EntityName}}> {
  constructor(protected client: ODataClient) {
    super(client, '{{EntitySetName}}', '{{EntityType}}');
  }{% if HasModel %}
  //#region ODataApi Model
  {{ModelName | methodcase}}(attrs?: Partial<{{EntityName}}>): {{ModelName}}<{{EntityName}}> {
    return this.entity().asModel<{{ModelName}}<{{EntityName}}>>(attrs || {});
  }//#endregion{% endif %}{% if HasCollection %}
  //#region ODataApi Collection
  {{CollectionName | methodcase}}(models?: Partial<{{EntityName}}>[]): {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>> {
    return this.entities().asCollection<{{ModelName}}<{{EntityName}}>, {{CollectionName}}<{{EntityName}}, {{ModelName}}<{{EntityName}}>>>(models || []);
  }//#endregion{% endif %}
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
