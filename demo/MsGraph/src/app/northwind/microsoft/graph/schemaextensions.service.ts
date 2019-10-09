import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { extensionSchemaProperty } from './extensionschemaproperty.interface';
import { schemaExtension } from './schemaextension.interface';


@Injectable()
export class SchemaExtensionsService extends ODataEntityService<schemaExtension> {
  static set: string = 'schemaExtensions';
  
  protected resolveEntityKey(entity: Partial<schemaExtension>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
