import { Airline, AirlineCollection } from './airline.model';
import { Airport, AirportCollection } from './airport.model';
import { PublicTransportation, PublicTransportationCollection } from './publictransportation.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Flight extends PublicTransportation {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Flight';
  static schema = PublicTransportation.schema.extend({
    fields: [
      {name: 'FlightNumber', type: 'String', required: true, collection: false}
    ],
    relationships: [
      {name: 'Airline', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airline', required: false, collection: false},
      {name: 'From', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airport', required: false, collection: false},
      {name: 'To', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airport', required: false, collection: false}
    ],
    defaults: {}
  });
  FlightNumber: string;
  Airline?: Airline;
  From?: Airport;
  To?: Airport;
}
export class FlightCollection extends ODataCollection<Flight> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Flight';
}