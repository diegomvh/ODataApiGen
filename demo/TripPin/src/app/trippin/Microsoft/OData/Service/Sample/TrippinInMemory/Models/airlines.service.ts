import { Airline, AirlineCollection } from './airline.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AirlinesService extends ODataModelService<Airline, AirlineCollection> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airline';
  static collection = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirlineCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Airlines');
  }
  
  protected resolveEntityKey(entity: Partial<Airline>) {
    return entity.AirlineCode;
  }
  
  model(attrs: any): Airline {
    return super.model(attrs) as Airline;
  }

  collection(attrs: any): AirlineCollection {
    return super.collection(attrs) as AirlineCollection;
  }

  
}