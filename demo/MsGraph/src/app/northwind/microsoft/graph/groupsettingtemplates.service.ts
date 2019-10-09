import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { settingTemplateValue } from './settingtemplatevalue.interface';
import { groupSettingTemplate } from './groupsettingtemplate.interface';


@Injectable()
export class GroupSettingTemplatesService extends ODataEntityService<groupSettingTemplate> {
  static set: string = 'groupSettingTemplates';
  
  protected resolveEntityKey(entity: Partial<groupSettingTemplate>) {
    return ;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
