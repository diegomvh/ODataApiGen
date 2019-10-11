import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet, ODataProperty } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

@Injectable()
export class {{Name}} extends ODataEntityService<{{EntityName}}> {
  static set: string = '{{EntitySet}}';
  schema = {{SchemaName}};
  
  protected resolveEntityKey(entity: Partial<{{EntityName}}>) {
    return {{ResolveKey}};
  }
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
