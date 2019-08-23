import { AirportLocation } from './airportlocation.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Airport extends ODataModel {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airport';
  static schema = Schema.create({
    fields: [
      {name: 'Name', type: 'String', required: true, collection: false},
      {name: 'IcaoCode', type: 'String', required: true, collection: false},
      {name: 'IataCode', type: 'String', required: true, collection: false},
      {name: 'Location', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirportLocation', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Name: string;
  IcaoCode: string;
  IataCode: string;
  Location: AirportLocation;
}
export class AirportCollection extends ODataCollection<Airport> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Airport';
}