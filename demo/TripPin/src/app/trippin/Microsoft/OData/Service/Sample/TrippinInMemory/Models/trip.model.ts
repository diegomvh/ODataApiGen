import { PlanItem, PlanItemCollection } from './planitem.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Trip extends ODataModel {
  static schema = Schema.create({
    fields: [
      {name: 'TripId', type: 'number', constructor: Number, required: true, collection: false},
      {name: 'ShareId', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Name', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Budget', type: 'number', constructor: Number, required: true, collection: false},
      {name: 'Description', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Tags', type: 'string', constructor: String, required: true, collection: true},
      {name: 'StartsAt', type: 'Date', constructor: Date, required: true, collection: false},
      {name: 'EndsAt', type: 'Date', constructor: Date, required: true, collection: false}
    ],
    relationships: [
      {name: 'PlanItems', type: 'PlanItem', constructor: PlanItem, required: false, collection: true}
    ],
    defaults: {}
  });
  TripId: number;
  ShareId: string;
  Name: string;
  Budget: number;
  Description: string;
  Tags: string;
  StartsAt: Date;
  EndsAt: Date;
}
export class TripCollection extends ODataCollection<Trip> {
  static Model = Trip;
}