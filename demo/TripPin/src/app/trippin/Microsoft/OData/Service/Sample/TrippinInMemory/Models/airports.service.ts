import { Airport, AirportCollection } from './airport.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AirportsService extends ODataModelService<Airport, AirportCollection> {
  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {
    super(http, context, 'Airports');
  }
  
  protected resolveEntityKey(entity) {
    return entity.IcaoCode;
  }
  
  
}