import { PlanItem, PlanItemCollection } from './planitem.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class PublicTransportation extends PlanItem {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'SeatNumber', type: 'string', constructor: String, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  SeatNumber: string;
}
export class PublicTransportationCollection extends ODataCollection<PublicTransportation> {
  static Model = PublicTransportation;
}