import { Employee } from '../../../NorthwindModel/employee.interface';
import { Region } from '../../../NorthwindModel/region.interface';
import { Territory } from '../../../NorthwindModel/territory.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class TerritoriesService extends ODataEntityService<Territory> {
  static set: string = 'Territories';
  
  protected resolveEntityKey(entity: Partial<Territory>) {
    return entity.TerritoryID;
  }
  
  public Region(entity: Territory, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<Region> {
    return this.navigationProperty<Region>(entity, 'Region', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'json',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public setRegionAsRegion<Region>(entity: Territory, target: ODataEntityRequest<Region>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'Region', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'json',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public unsetRegionAsRegion<Region>(entity: Territory, target: ODataEntityRequest<Region>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'Region', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'json',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public Employees(entity: Territory, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<Employee>> {
    return this.navigationProperty<Employee>(entity, 'Employees', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public addEmployeeToEmployees<Employee>(entity: Territory, target: ODataEntityRequest<Employee>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'Employees', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public removeEmployeeFromEmployees<Employee>(entity: Territory, target: ODataEntityRequest<Employee>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'Employees', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
}