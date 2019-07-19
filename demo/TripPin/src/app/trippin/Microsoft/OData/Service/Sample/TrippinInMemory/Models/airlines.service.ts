import { Airline, AirlineCollection } from './airline.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AirlinesService extends ODataModelService<Airline, AirlineCollection> {
  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {
    super(http, context, 'Airlines');
  }
  
  protected resolveEntityKey(entity) {
    return entity.AirlineCode;
  }
  
  
}