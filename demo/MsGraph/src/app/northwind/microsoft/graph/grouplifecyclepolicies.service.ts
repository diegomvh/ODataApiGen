import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { groupLifecyclePolicy } from './grouplifecyclepolicy.interface';


@Injectable()
export class GroupLifecyclePoliciesService extends ODataEntityService<groupLifecyclePolicy> {
  static set: string = 'groupLifecyclePolicies';
  
  protected resolveEntityKey(entity: Partial<groupLifecyclePolicy>) {
    return entity.id;
  }
  // Actions
  public addGroup(grouplifecyclepolicyId: any, groupId: string, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<boolean> {
    var body = Object.entries({ groupId })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<boolean>(grouplifecyclepolicyId, 'microsoft.graph.addGroup',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'property',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public removeGroup(grouplifecyclepolicyId: any, groupId: string, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<boolean> {
    var body = Object.entries({ groupId })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<boolean>(grouplifecyclepolicyId, 'microsoft.graph.removeGroup',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'property',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Functions
  
  // Navigations
  
}
