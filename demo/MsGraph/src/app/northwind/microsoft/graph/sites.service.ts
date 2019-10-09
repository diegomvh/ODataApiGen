import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { root } from './root.interface';
import { sharepointIds } from './sharepointids.interface';
import { siteCollection } from './sitecollection.interface';
import { baseItem } from './baseitem.interface';
import { drive } from './drive.interface';
import { onenote } from './onenote.interface';
import { site } from './site.interface';
import { itemAnalytics } from './itemanalytics.interface';
import { columnDefinition } from './columndefinition.interface';
import { contentType } from './contenttype.interface';
import { list } from './list.interface';
import { itemActivityStat } from './itemactivitystat.interface';


@Injectable()
export class SitesService extends ODataEntityService<site> {
  static set: string = 'sites';
  
  protected resolveEntityKey(entity: Partial<site>) {
    return ;
  }
  // Actions
  
  // Functions
  public getActivitiesByInterval(siteId: any, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<itemActivityStat>> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customFunction<itemActivityStat>(siteId, 'microsoft.graph.getActivitiesByInterval',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entityset',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public getByPath(siteId: any, path: string, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<site> {
    var body = Object.entries({ path })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customFunction<site>(siteId, 'microsoft.graph.getByPath',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Navigations
  public analytics(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<itemAnalytics> {
    return this.navigationProperty<itemAnalytics>(entity, 'analytics', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public setitemAnalyticsAsAnalytics<itemAnalytics>(entity: site, target: ODataEntityRequest<itemAnalytics>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'analytics', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public unsetitemAnalyticsAsAnalytics<itemAnalytics>(entity: site, target?: ODataEntityRequest<itemAnalytics>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'analytics', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public columns(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<columnDefinition>> {
    return this.navigationProperty<columnDefinition>(entity, 'columns', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addcolumnDefinitionToColumns<columnDefinition>(entity: site, target: ODataEntityRequest<columnDefinition>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'columns', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removecolumnDefinitionFromColumns<columnDefinition>(entity: site, target?: ODataEntityRequest<columnDefinition>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'columns', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public contentTypes(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<contentType>> {
    return this.navigationProperty<contentType>(entity, 'contentTypes', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addcontentTypeToContentTypes<contentType>(entity: site, target: ODataEntityRequest<contentType>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'contentTypes', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removecontentTypeFromContentTypes<contentType>(entity: site, target?: ODataEntityRequest<contentType>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'contentTypes', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public drive(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<drive> {
    return this.navigationProperty<drive>(entity, 'drive', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public setdriveAsDrive<drive>(entity: site, target: ODataEntityRequest<drive>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'drive', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public unsetdriveAsDrive<drive>(entity: site, target?: ODataEntityRequest<drive>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'drive', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public drives(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<drive>> {
    return this.navigationProperty<drive>(entity, 'drives', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public adddriveToDrives<drive>(entity: site, target: ODataEntityRequest<drive>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'drives', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removedriveFromDrives<drive>(entity: site, target?: ODataEntityRequest<drive>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'drives', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public items(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<baseItem>> {
    return this.navigationProperty<baseItem>(entity, 'items', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addbaseItemToItems<baseItem>(entity: site, target: ODataEntityRequest<baseItem>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'items', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removebaseItemFromItems<baseItem>(entity: site, target?: ODataEntityRequest<baseItem>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'items', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public lists(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<list>> {
    return this.navigationProperty<list>(entity, 'lists', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addlistToLists<list>(entity: site, target: ODataEntityRequest<list>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'lists', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removelistFromLists<list>(entity: site, target?: ODataEntityRequest<list>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'lists', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public sites(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<site>> {
    return this.navigationProperty<site>(entity, 'sites', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addsiteToSites<site>(entity: site, target: ODataEntityRequest<site>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'sites', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removesiteFromSites<site>(entity: site, target?: ODataEntityRequest<site>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'sites', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public onenote(entity: site, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<onenote> {
    return this.navigationProperty<onenote>(entity, 'onenote', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public setonenoteAsOnenote<onenote>(entity: site, target: ODataEntityRequest<onenote>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'onenote', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public unsetonenoteAsOnenote<onenote>(entity: site, target?: ODataEntityRequest<onenote>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'onenote', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  
}
