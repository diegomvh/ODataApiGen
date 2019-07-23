import { Location } from './location.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class EventLocation extends Location {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.EventLocation';
  static schema = Location.schema.extend({
    fields: [
      {name: 'BuildingInfo', type: 'String', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  BuildingInfo: string;
}