import { Airline, AirlineCollection } from './airline.model';
import { Airport, AirportCollection } from './airport.model';
import { PublicTransportation, PublicTransportationCollection } from './publictransportation.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Flight extends PublicTransportation {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'FlightNumber', type: 'string', constructor: String, required: true, collection: false}
    ],
    relationships: [
      {name: 'Airline', type: 'Airline', constructor: Airline, required: false, collection: false},
      {name: 'From', type: 'Airport', constructor: Airport, required: false, collection: false},
      {name: 'To', type: 'Airport', constructor: Airport, required: false, collection: false}
    ],
    defaults: {}
  });
  FlightNumber: string;
}
export class FlightCollection extends ODataCollection<Flight> {
  static Model = Flight;
}