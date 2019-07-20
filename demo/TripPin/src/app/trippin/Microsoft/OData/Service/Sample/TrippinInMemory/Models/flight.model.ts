import { Airline, AirlineCollection } from './airline.model';
import { Airport, AirportCollection } from './airport.model';
import { PublicTransportation, PublicTransportationCollection } from './publictransportation.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const FlightSchema = new ODataModelSchema({
  fields: [
    {name: 'FlightNumber', type: 'string', required: false, length: 0, collection: false}
  ],
  relations: [
    {name: 'Airline', type: 'Airline', required: false, length: 0, collection: false},
      {name: 'From', type: 'Airport', required: false, length: 0, collection: false},
      {name: 'To', type: 'Airport', required: false, length: 0, collection: false}
  ],
  defaults: {}
});

export class Flight extends PublicTransportation {
  FlightNumber?: string;
  protected schema: ODataModelSchema = FlightSchema;
}

export class FlightCollection extends ODataCollection<Flight> {
}