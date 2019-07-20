
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const PlanItemSchema = new ODataModelSchema({
  fields: [
    {name: 'PlanItemId', type: 'number', required: true, length: 0, collection: false},
      {name: 'ConfirmationCode', type: 'string', required: false, length: 0, collection: false},
      {name: 'StartsAt', type: 'Date', required: true, length: 0, collection: false},
      {name: 'EndsAt', type: 'Date', required: true, length: 0, collection: false},
      {name: 'Duration', type: 'string', required: true, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class PlanItem extends ODataModel {
  PlanItemId: number;
  ConfirmationCode?: string;
  StartsAt: Date;
  EndsAt: Date;
  Duration: string;
  protected schema: ODataModelSchema = PlanItemSchema;
}

export class PlanItemCollection extends ODataCollection<PlanItem> {
}