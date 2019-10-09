import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { settingValue } from './settingvalue.interface';
import { groupSetting } from './groupsetting.interface';


@Injectable()
export class GroupSettingsService extends ODataEntityService<groupSetting> {
  static set: string = 'groupSettings';
  
  protected resolveEntityKey(entity: Partial<groupSetting>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
