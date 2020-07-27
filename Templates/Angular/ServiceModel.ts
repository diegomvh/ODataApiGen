import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { 
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
export class {{Name}} extends ODataModelService<{{EntityName}}, {{EntityName}}Model<{{EntityName}}>, {{EntityName}}Collection<{{EntityName}}, {{EntityName}}Model<{{EntityName}}>>> {
  static path: string = '{{EntitySetName}}';
  static type: string = '{{ServiceType}}';
  static entityType: string = '{{EntityType}}';
}
