import { ODataModel, Schema } from 'angular-odata';

import { AirportLocation } from './airportlocation.model';
import { AirportLocationCollection } from './airportlocation.collection';

export class Airport extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      {name: 'IcaoCode'}
    ],
    fields: [
      {name: 'IcaoCode', type: 'String', required: true},
      {name: 'Name', type: 'String', required: true},
      {name: 'IataCode', type: 'String', required: true},
      {name: 'Location', type: 'Microsoft.OData.SampleService.Models.TripPin.AirportLocation', required: true}
    ]
  });
  IcaoCode: string;
  Name: string;
  IataCode: string;
  Location: AirportLocation
}