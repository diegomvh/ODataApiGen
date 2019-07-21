import { AirportLocation, AirportLocationCollection } from './airportlocation.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Airport extends ODataModel {
  static schema = Schema.create({
    fields: [
      {name: 'Name', type: 'string', constructor: String, required: true, collection: false},
      {name: 'IcaoCode', type: 'string', constructor: String, required: true, collection: false},
      {name: 'IataCode', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Location', type: 'AirportLocation', constructor: AirportLocation, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Name: string;
  IcaoCode: string;
  IataCode: string;
  Location: AirportLocation;
}
export class AirportCollection extends ODataCollection<Airport> {
  static Model = Airport;
}