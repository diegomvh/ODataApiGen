import { PlanItem, PlanItemCollection } from './planitem.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class PublicTransportation extends PlanItem {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PublicTransportation';
  static schema = PlanItem.schema.extend({
    fields: [
      {name: 'SeatNumber', type: 'String', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  SeatNumber: string;
}
export class PublicTransportationCollection extends ODataCollection<PublicTransportation> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PublicTransportation';
}