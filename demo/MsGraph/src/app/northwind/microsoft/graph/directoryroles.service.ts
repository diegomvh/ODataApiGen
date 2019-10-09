import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { directoryObject } from './directoryobject.interface';
import { directoryRole } from './directoryrole.interface';


@Injectable()
export class DirectoryRolesService extends ODataEntityService<directoryRole> {
  static set: string = 'directoryRoles';
  
  protected resolveEntityKey(entity: Partial<directoryRole>) {
    return ;
  }
  // Actions
  
  // Functions
  public delta(options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<directoryRole>> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customCollectionFunction<directoryRole>('microsoft.graph.delta',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entityset',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Navigations
  public members(entity: directoryRole, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<directoryObject>> {
    return this.navigationProperty<directoryObject>(entity, 'members', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public adddirectoryObjectToMembers<directoryObject>(entity: directoryRole, target: ODataEntityRequest<directoryObject>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'members', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removedirectoryObjectFromMembers<directoryObject>(entity: directoryRole, target?: ODataEntityRequest<directoryObject>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'members', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  
}
