import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { directoryRoleTemplate } from './directoryroletemplate.interface';


@Injectable()
export class DirectoryRoleTemplatesService extends ODataEntityService<directoryRoleTemplate> {
  static set: string = 'directoryRoleTemplates';
  
  protected resolveEntityKey(entity: Partial<directoryRoleTemplate>) {
    return ;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
