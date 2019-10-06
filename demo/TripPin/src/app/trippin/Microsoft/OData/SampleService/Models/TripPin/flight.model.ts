import { ODataModel, Schema } from 'angular-odata';

import { Airline } from './airline.model';
import { Airport } from './airport.model';
import { PublicTransportation } from './publictransportation.model';
import { AirlineCollection } from './airline.collection';
import { AirportCollection } from './airport.collection';
import { PublicTransportationCollection } from './publictransportation.collection';

export class Flight extends PublicTransportation {
  static schema = PublicTransportation.schema.extend({ 
    keys: [
      
    ],
    fields: [
      {name: 'FlightNumber', type: 'String', required: true},
      {name: 'From', type: 'Microsoft.OData.SampleService.Models.TripPin.Airport', navigation: true},
      {name: 'To', type: 'Microsoft.OData.SampleService.Models.TripPin.Airport', navigation: true},
      {name: 'Airline', type: 'Microsoft.OData.SampleService.Models.TripPin.Airline', navigation: true}
    ]
  });
  FlightNumber: string;
  From?: Airport;
  To?: Airport;
  Airline?: Airline
}