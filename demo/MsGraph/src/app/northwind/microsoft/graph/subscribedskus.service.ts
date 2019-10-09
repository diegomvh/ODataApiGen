import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { servicePlanInfo } from './serviceplaninfo.interface';
import { licenseUnitsDetail } from './licenseunitsdetail.interface';
import { subscribedSku } from './subscribedsku.interface';


@Injectable()
export class SubscribedSkusService extends ODataEntityService<subscribedSku> {
  static set: string = 'subscribedSkus';
  
  protected resolveEntityKey(entity: Partial<subscribedSku>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
