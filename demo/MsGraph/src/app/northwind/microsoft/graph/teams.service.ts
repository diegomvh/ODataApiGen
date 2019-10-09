import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

import { teamMemberSettings } from './teammembersettings.interface';
import { teamGuestSettings } from './teamguestsettings.interface';
import { teamMessagingSettings } from './teammessagingsettings.interface';
import { teamFunSettings } from './teamfunsettings.interface';
import { team } from './team.interface';
import { channel } from './channel.interface';
import { teamsAppInstallation } from './teamsappinstallation.interface';
import { teamsAsyncOperation } from './teamsasyncoperation.interface';


@Injectable()
export class TeamsService extends ODataEntityService<team> {
  static set: string = 'teams';
  
  protected resolveEntityKey(entity: Partial<team>) {
    return entity.id;
  }
  // Actions
  public clone(teamId: any, displayName: string, description: string, mailNickname: string, classification: string, visibility: teamVisibilityType, partsToClone: clonableTeamParts, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<any> {
    var body = Object.entries({ displayName, description, mailNickname, classification, visibility, partsToClone })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<any>(teamId, 'microsoft.graph.clone',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public archive(teamId: any, shouldSetSpoSiteReadOnlyForMembers: boolean, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<any> {
    var body = Object.entries({ shouldSetSpoSiteReadOnlyForMembers })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<any>(teamId, 'microsoft.graph.archive',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  public unarchive(teamId: any, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<any> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.customAction<any>(teamId, 'microsoft.graph.unarchive',body, {
      headers: options && options.headers,
      params: options && options.params,
      responseType: 'entity',
      reportProgress: options && options.reportProgress,
      withCredentials: options && options.withCredentials
    });
  }
  
  // Functions
  
  // Navigations
  public channels(entity: team, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<channel>> {
    return this.navigationProperty<channel>(entity, 'channels', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addchannelToChannels<channel>(entity: team, target: ODataEntityRequest<channel>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'channels', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removechannelFromChannels<channel>(entity: team, target?: ODataEntityRequest<channel>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'channels', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public installedApps(entity: team, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<teamsAppInstallation>> {
    return this.navigationProperty<teamsAppInstallation>(entity, 'installedApps', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addteamsAppInstallationToInstalledApps<teamsAppInstallation>(entity: team, target: ODataEntityRequest<teamsAppInstallation>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'installedApps', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removeteamsAppInstallationFromInstalledApps<teamsAppInstallation>(entity: team, target?: ODataEntityRequest<teamsAppInstallation>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'installedApps', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public operations(entity: team, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<teamsAsyncOperation>> {
    return this.navigationProperty<teamsAsyncOperation>(entity, 'operations', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public addteamsAsyncOperationToOperations<teamsAsyncOperation>(entity: team, target: ODataEntityRequest<teamsAsyncOperation>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'operations', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  public removeteamsAsyncOperationFromOperations<teamsAsyncOperation>(entity: team, target?: ODataEntityRequest<teamsAsyncOperation>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'operations', {
        target: target,
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
  
}
