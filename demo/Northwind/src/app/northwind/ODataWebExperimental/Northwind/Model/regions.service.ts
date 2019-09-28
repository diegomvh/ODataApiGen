import { Region } from '../../../NorthwindModel/region.interface';
import { Territory } from '../../../NorthwindModel/territory.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class RegionsService extends ODataEntityService<Region> {
  static set: string = 'Regions';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Region>) {
    return entity.RegionID;
  }
  
  public Territories(entity: Region, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<Territory>> {
    return this.navigationProperty<Territory>(entity, 'Territories', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public addTerritoryToTerritories<Territory>(entity: Region, target: ODataEntityRequest<Territory>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'Territories', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public removeTerritoryFromTerritories<Territory>(entity: Region, target: ODataEntityRequest<Territory>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'Territories', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entityset',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
}