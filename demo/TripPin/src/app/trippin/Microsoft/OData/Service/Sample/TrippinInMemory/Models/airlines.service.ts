import { Airline, AirlineCollection } from './airline.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AirlinesService extends ODataModelService<Airline, AirlineCollection> {
  static Model = Airline;
  static Collection = AirlineCollection;

  constructor(
    protected http: HttpClient,
    protected context: ODataContext
  ) {
    super(http, context, 'Airlines');
  }
  
  protected resolveEntityKey(entity: Partial<Airline>) {
    return entity.AirlineCode;
  }
  
  
}