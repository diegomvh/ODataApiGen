import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { invitedUserMessageInfo } from './invitedusermessageinfo.interface';
import { invitation } from './invitation.interface';
import { user } from './user.interface';


@Injectable()
export class InvitationsService extends ODataEntityService<invitation> {
  static set: string = 'invitations';
  
  protected resolveEntityKey(entity: Partial<invitation>) {
    return entity.id;
  }
  // Actions
  
  // Functions
  
  // Navigations
  public invitedUser(entity: invitation, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<user> {
    return this.navigationProperty<user>(entity, 'invitedUser', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public setuserAsInvitedUser<user>(entity: invitation, target: ODataEntityRequest<user>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'invitedUser', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public unsetuserAsInvitedUser<user>(entity: invitation, target?: ODataEntityRequest<user>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'invitedUser', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  
}
