import { Injectable } from '@angular/core';

import { ODataModelService } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

@Injectable()
export class {{Name}} extends ODataModelService<{{ModelName}}, {{CollectionName}}> {
  static set: string = '{{EntityName}}';
  static type: string = '{{ModelType}}';
  
}