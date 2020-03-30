import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityAnnotations, ODataEntitiesAnnotations, ODataPropertyAnnotations, ODataEntityResource, HttpOptions } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

@Injectable()
export class {{Name}} extends ODataEntityService<{{EntityName}}> {
  static path: string = '{{ResourcePath}}';
  static type: string = '{{EntityType}}';
  
  // Actions
  {% for action in Actions %}{{action}}
  {% endfor %}
  // Functions
  {% for func in Functions %}{{func}}
  {% endfor %}
  // Navigations
  {% for nav in Navigations %}{{nav}}
  {% endfor %}
}
