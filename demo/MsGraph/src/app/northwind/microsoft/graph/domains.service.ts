import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { domainState } from './domainstate.interface';
import { directoryObject } from './directoryobject.interface';
import { domain } from './domain.interface';
import { domainDnsRecord } from './domaindnsrecord.interface';


@Injectable()
export class DomainsService extends ODataEntityService<domain> {
  static set: string = 'domains';
  
  protected resolveEntityKey(entity: Partial<domain>) {
    return entity.id;
  }
  // Actions
  public forceDelete(domainId: any, disableUserAccounts: boolean, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<any> {
    var body = Object.entries({ disableUserAccounts })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<any>(domainId, 'microsoft.graph.forceDelete',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public verify(domainId: any, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<domain> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<domain>(domainId, 'microsoft.graph.verify',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Functions
  
  // Navigations
  public serviceConfigurationRecords(entity: domain, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<domainDnsRecord>> {
    return this.navigationProperty<domainDnsRecord>(entity, 'serviceConfigurationRecords', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public adddomainDnsRecordToServiceConfigurationRecords<domainDnsRecord>(entity: domain, target: ODataEntityRequest<domainDnsRecord>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'serviceConfigurationRecords', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removedomainDnsRecordFromServiceConfigurationRecords<domainDnsRecord>(entity: domain, target?: ODataEntityRequest<domainDnsRecord>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'serviceConfigurationRecords', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public verificationDnsRecords(entity: domain, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<domainDnsRecord>> {
    return this.navigationProperty<domainDnsRecord>(entity, 'verificationDnsRecords', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public adddomainDnsRecordToVerificationDnsRecords<domainDnsRecord>(entity: domain, target: ODataEntityRequest<domainDnsRecord>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'verificationDnsRecords', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removedomainDnsRecordFromVerificationDnsRecords<domainDnsRecord>(entity: domain, target?: ODataEntityRequest<domainDnsRecord>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'verificationDnsRecords', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public domainNameReferences(entity: domain, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<directoryObject>> {
    return this.navigationProperty<directoryObject>(entity, 'domainNameReferences', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public adddirectoryObjectToDomainNameReferences<directoryObject>(entity: domain, target: ODataEntityRequest<directoryObject>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'domainNameReferences', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removedirectoryObjectFromDomainNameReferences<directoryObject>(entity: domain, target?: ODataEntityRequest<directoryObject>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'domainNameReferences', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  
}
