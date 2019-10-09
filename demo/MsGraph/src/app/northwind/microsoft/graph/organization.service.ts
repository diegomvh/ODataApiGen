import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { mdmAuthority } from './mdmauthority.enum';
import { assignedPlan } from './assignedplan.interface';
import { provisionedPlan } from './provisionedplan.interface';
import { privacyProfile } from './privacyprofile.interface';
import { verifiedDomain } from './verifieddomain.interface';
import { extension } from './extension.interface';
import { organization } from './organization.interface';


@Injectable()
export class OrganizationService extends ODataEntityService<organization> {
  static set: string = 'organization';
  
  protected resolveEntityKey(entity: Partial<organization>) {
    return ;
  }
  // Actions
  public setMobileDeviceManagementAuthority(organizationId: any, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<number> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<number>(organizationId, 'microsoft.graph.setMobileDeviceManagementAuthority',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'property',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Functions
  
  // Navigations
  public extensions(entity: organization, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<extension>> {
    return this.navigationProperty<extension>(entity, 'extensions', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addextensionToExtensions<extension>(entity: organization, target: ODataEntityRequest<extension>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'extensions', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removeextensionFromExtensions<extension>(entity: organization, target?: ODataEntityRequest<extension>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'extensions', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  
}
