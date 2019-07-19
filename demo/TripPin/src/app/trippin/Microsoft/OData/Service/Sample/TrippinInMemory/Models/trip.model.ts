import { PlanItem, PlanItemCollection } from './planitem.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Trip extends ODataModel {
  TripId: number;
  ShareId: string;
  Name?: string;
  Budget: number;
  Description?: string;
  Tags?: string;
  StartsAt: Date;
  EndsAt: Date;
  private static _meta: ODataModelOptions<Trip> = new ODataModelOptions<Trip>({
    fields: [
      {name: 'TripId', type: 'number', required: true, length: 0, collection: false},
      {name: 'ShareId', type: 'string', required: true, length: 0, collection: false},
      {name: 'Name', type: 'string', required: false, length: 0, collection: false},
      {name: 'Budget', type: 'number', required: true, length: 0, collection: false},
      {name: 'Description', type: 'string', required: false, length: 0, collection: false},
      {name: 'Tags', type: 'string', required: false, length: 0, collection: true},
      {name: 'StartsAt', type: 'Date', required: true, length: 0, collection: false},
      {name: 'EndsAt', type: 'Date', required: true, length: 0, collection: false}
    ],
    relations: [
      {name: 'PlanItems', type: 'PlanItem', required: false, length: 0, collection: true}
    ],
    defaults: {}
  });
  protected meta() { return Trip._meta; }
}

export class TripCollection extends ODataCollection<Trip> {
}