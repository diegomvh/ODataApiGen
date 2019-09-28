import { AirportLocation } from './airportlocation.interface';
import { Airport } from './airport.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class AirportsService extends ODataEntityService<Airport> {
  static set: string = 'Airports';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Airport>) {
    return entity.IcaoCode;
  }
  
  
}