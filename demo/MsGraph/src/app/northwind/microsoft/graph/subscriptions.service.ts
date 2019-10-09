import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { subscription } from './subscription.interface';


@Injectable()
export class SubscriptionsService extends ODataEntityService<subscription> {
  static set: string = 'subscriptions';
  
  protected resolveEntityKey(entity: Partial<subscription>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  
}
