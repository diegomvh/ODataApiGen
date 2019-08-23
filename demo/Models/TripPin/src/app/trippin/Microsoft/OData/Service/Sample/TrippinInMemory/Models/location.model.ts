import { City } from './city.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Location extends Model {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Location';
  static schema = Schema.create({
    fields: [
      {name: 'Address', type: 'String', required: true, collection: false},
      {name: 'City', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.City', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Address: string;
  City: City;
}