import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataModelService, ODataEntityAnnotations, ODataEntitiesAnnotations, ODataPropertyAnnotations, ODataEntityResource } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

@Injectable()
export class {{Name}} extends ODataModelService<{{EntityName}}, {{EntityName}}Model, {{EntityName}}Collection> {
  static path: string = '{{ResourcePath}}';
  static type: string = '{{EntityType}}';
}
