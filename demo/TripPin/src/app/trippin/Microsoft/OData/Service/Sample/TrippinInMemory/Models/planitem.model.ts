
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class PlanItem extends ODataModel {
  static schema = Schema.create({
    fields: [
      {name: 'PlanItemId', type: 'number', constructor: Number, required: true, collection: false},
      {name: 'ConfirmationCode', type: 'string', constructor: String, required: true, collection: false},
      {name: 'StartsAt', type: 'Date', constructor: Date, required: true, collection: false},
      {name: 'EndsAt', type: 'Date', constructor: Date, required: true, collection: false},
      {name: 'Duration', type: 'string', constructor: String, required: true, collection: false}
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
  static Model = PlanItem;
}