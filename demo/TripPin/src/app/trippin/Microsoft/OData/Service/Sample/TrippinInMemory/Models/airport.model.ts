import { AirportLocation, AirportLocationCollection } from './airportlocation.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const AirportSchema = new ODataModelSchema({
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

export class Airport extends ODataModel {
  Name?: string;
  IcaoCode: string;
  IataCode?: string;
  Location?: AirportLocation;
  protected schema: ODataModelSchema = AirportSchema;
}

export class AirportCollection extends ODataCollection<Airport> {
}