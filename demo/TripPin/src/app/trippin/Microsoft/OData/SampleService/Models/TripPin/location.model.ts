import { ODataModel, Schema } from 'angular-odata';

import { City } from './city.model';
import { CityCollection } from './city.collection';

export class Location extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      
    ],
    fields: [
      {name: 'Address', type: 'String', required: true},
      {name: 'City', type: 'Microsoft.OData.SampleService.Models.TripPin.City', required: true}
    ]
  });
  Address: string;
  City: City
}