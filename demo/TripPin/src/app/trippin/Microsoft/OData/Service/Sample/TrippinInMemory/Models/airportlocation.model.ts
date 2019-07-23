import { Location } from './location.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class AirportLocation extends Location {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.AirportLocation';
  static schema = Location.schema.extend({
    fields: [
      {name: 'Loc', type: 'Object', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Loc: any;
}