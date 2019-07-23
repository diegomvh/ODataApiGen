
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Airline extends ODataModel {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airline';
  static schema = Schema.create({
    fields: [
      {name: 'AirlineCode', type: 'String', required: true, collection: false},
      {name: 'Name', type: 'String', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  AirlineCode: string;
  Name: string;
}
export class AirlineCollection extends ODataCollection<Airline> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airline';
}