
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class PlanItem extends ODataModel {
  PlanItemId: number;
  ConfirmationCode?: string;
  StartsAt: Date;
  EndsAt: Date;
  Duration: string;
  private static _meta: ODataModelOptions<PlanItem> = new ODataModelOptions<PlanItem>({
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
  protected meta() { return PlanItem._meta; }
}

export class PlanItemCollection extends ODataCollection<PlanItem> {
}