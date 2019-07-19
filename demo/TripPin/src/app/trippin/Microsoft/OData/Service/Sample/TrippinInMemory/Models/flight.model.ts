import { Airline, AirlineCollection } from './airline.model';
import { Airport, AirportCollection } from './airport.model';
import { PublicTransportation, PublicTransportationCollection } from './publictransportation.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Flight extends PublicTransportation {
  FlightNumber?: string;
  private static _meta: ODataModelOptions<Flight> = new ODataModelOptions<Flight>({
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
  protected meta() { return Flight._meta; }
}

export class FlightCollection extends ODataCollection<Flight> {
}