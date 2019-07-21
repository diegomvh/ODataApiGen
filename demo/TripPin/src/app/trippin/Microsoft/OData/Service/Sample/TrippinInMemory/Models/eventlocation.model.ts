import { Location, LocationCollection } from './location.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class EventLocation extends Location {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'BuildingInfo', type: 'string', constructor: String, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  BuildingInfo: string;
}