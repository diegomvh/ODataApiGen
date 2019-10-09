import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { directoryObject } from './directoryobject.interface';


@Injectable()
export class DirectoryObjectsService extends ODataEntityService<directoryObject> {
  static set: string = 'directoryObjects';
  
  protected resolveEntityKey(entity: Partial<directoryObject>) {
    return entity.id;
  }
  // Actions
  public getByIds(ids: string[], types: string[], options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<directoryObject>> {
    var body = Object.entries({ ids, types })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customCollectionAction<directoryObject>('microsoft.graph.getByIds',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entityset',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public validateProperties(entityType: string, displayName: string, mailNickname: string, onBehalfOfUserId: string, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<any> {
    var body = Object.entries({ entityType, displayName, mailNickname, onBehalfOfUserId })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customCollectionAction<any>('microsoft.graph.validateProperties',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public checkMemberGroups(directoryobjectId: any, groupIds: string[], options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<string>> {
    var body = Object.entries({ groupIds })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<string>(directoryobjectId, 'microsoft.graph.checkMemberGroups',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'property',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public getMemberGroups(directoryobjectId: any, securityEnabledOnly: boolean, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<string>> {
    var body = Object.entries({ securityEnabledOnly })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<string>(directoryobjectId, 'microsoft.graph.getMemberGroups',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'property',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public getMemberObjects(directoryobjectId: any, securityEnabledOnly: boolean, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<string>> {
    var body = Object.entries({ securityEnabledOnly })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<string>(directoryobjectId, 'microsoft.graph.getMemberObjects',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'property',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public restore(directoryobjectId: any, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<directoryObject> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<directoryObject>(directoryobjectId, 'microsoft.graph.restore',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Functions
  
  // Navigations
  
}
