import { AirportLocation, AirportLocationCollection } from './airportlocation.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Airport extends ODataModel {
  Name?: string;
  IcaoCode: string;
  IataCode?: string;
  Location?: AirportLocation;
  private static _meta: ODataModelOptions<Airport> = new ODataModelOptions<Airport>({
    fields: [
      {name: 'Name', type: 'string', required: false, length: 0, collection: false},
      {name: 'IcaoCode', type: 'string', required: true, length: 0, collection: false},
      {name: 'IataCode', type: 'string', required: false, length: 0, collection: false},
      {name: 'Location', type: 'AirportLocation', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return Airport._meta; }
}

export class AirportCollection extends ODataCollection<Airport> {
}