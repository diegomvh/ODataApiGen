import { ODataModel, Schema } from 'angular-odata';


export class PlanItem extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      {name: 'PlanItemId'}
    ],
    fields: [
      {name: 'PlanItemId', type: 'Number', required: true},
      {name: 'ConfirmationCode', type: 'String', required: true},
      {name: 'StartsAt', type: 'Date', required: true},
      {name: 'EndsAt', type: 'Date', required: true},
      {name: 'Duration', type: 'String', required: true}
    ]
  });
  PlanItemId: number;
  ConfirmationCode: string;
  StartsAt: Date;
  EndsAt: Date;
  Duration: string
}