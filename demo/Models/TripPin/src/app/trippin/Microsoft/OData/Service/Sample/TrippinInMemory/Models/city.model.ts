
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class City extends Model {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.City';
  static schema = Schema.create({
    fields: [
      {name: 'Name', type: 'String', required: true, collection: false},
      {name: 'CountryRegion', type: 'String', required: true, collection: false},
      {name: 'Region', type: 'String', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Name: string;
  CountryRegion: string;
  Region: string;
}