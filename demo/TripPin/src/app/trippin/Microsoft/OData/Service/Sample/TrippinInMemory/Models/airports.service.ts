import { AirportLocation } from './airportlocation.model';
import { Airport, AirportCollection } from './airport.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AirportsService extends ODataModelService<Airport, AirportCollection> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airport';
  static collection = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirportCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Airports');
  }
  
  protected resolveEntityKey(entity: Partial<Airport>) {
    return entity.IcaoCode;
  }
  
  model(attrs: any): Airport {
    return super.model(attrs) as Airport;
  }

  collection(attrs: any): AirportCollection {
    return super.collection(attrs) as AirportCollection;
  }

  
}