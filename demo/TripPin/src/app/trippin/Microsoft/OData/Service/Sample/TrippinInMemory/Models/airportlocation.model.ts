import { Location, LocationCollection } from './location.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class AirportLocation extends Location {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'Loc', type: 'any', constructor: Object, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Loc: any;
}