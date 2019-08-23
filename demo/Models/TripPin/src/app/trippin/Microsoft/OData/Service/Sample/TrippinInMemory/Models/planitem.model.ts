
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class PlanItem extends ODataModel {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PlanItem';
  static schema = Schema.create({
    fields: [
      {name: 'PlanItemId', type: 'Number', required: true, collection: false},
      {name: 'ConfirmationCode', type: 'String', required: true, collection: false},
      {name: 'StartsAt', type: 'Date', required: true, collection: false},
      {name: 'EndsAt', type: 'Date', required: true, collection: false},
      {name: 'Duration', type: 'String', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  PlanItemId: number;
  ConfirmationCode: string;
  StartsAt: Date;
  EndsAt: Date;
  Duration: string;
}
export class PlanItemCollection extends ODataCollection<PlanItem> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PlanItem';
}