import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataClient, ODataEntityAnnotations, ODataCollectionAnnotations, ODataPropertyAnnotations, ODataEntityResource } from 'angular-odata';

import { Airport } from './Microsoft/OData/SampleService/Models/TripPin/airport.entity';


@Injectable()
export class TripPinService {
 
  constructor(protected client: ODataClient) { }

  // Actions
  public resetDataSource(options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<[any, ODataEntityAnnotations]> {
    var body = Object.entries({  })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.client.action<any>('ResetDataSource')
      .post(body, {
        headers: options && options.headers,
        params: options && options.params,
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
      });
  }
  
  // Functions
  public getNearestAirport(lat: number, lon: number, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<[Airport, ODataEntityAnnotations]> {
    var body = Object.entries({ lat, lon })
      .filter(pair => pair[1] !== null)
      .reduce((acc, val) => (acc[val[0]] = val[1], acc), {});
    return this.client.function<Airport>('GetNearestAirport', body, 'Microsoft.OData.SampleService.Models.TripPin.Airport')
      .get({
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'entity',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
      });
  }
  
}