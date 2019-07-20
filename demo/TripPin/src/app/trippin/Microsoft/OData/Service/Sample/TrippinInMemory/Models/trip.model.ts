import { PlanItem, PlanItemCollection } from './planitem.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const TripSchema = new ODataModelSchema({
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

export class Trip extends ODataModel {
  TripId: number;
  ShareId: string;
  Name?: string;
  Budget: number;
  Description?: string;
  Tags?: string;
  StartsAt: Date;
  EndsAt: Date;
  protected schema: ODataModelSchema = TripSchema;
}

export class TripCollection extends ODataCollection<Trip> {
}