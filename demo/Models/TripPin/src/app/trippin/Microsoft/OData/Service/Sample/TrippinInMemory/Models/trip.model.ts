import { PlanItem, PlanItemCollection } from './planitem.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Trip extends ODataModel {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Trip';
  static schema = Schema.create({
    fields: [
      {name: 'TripId', type: 'Number', required: true, collection: false},
      {name: 'ShareId', type: 'String', required: true, collection: false},
      {name: 'Name', type: 'String', required: true, collection: false},
      {name: 'Budget', type: 'Number', required: true, collection: false},
      {name: 'Description', type: 'String', required: true, collection: false},
      {name: 'Tags', type: 'String', required: true, collection: true},
      {name: 'StartsAt', type: 'Date', required: true, collection: false},
      {name: 'EndsAt', type: 'Date', required: true, collection: false}
    ],
    relationships: [
      {name: 'PlanItems', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.PlanItem', required: false, collection: true}
    ],
    defaults: {}
  });
  TripId: number;
  ShareId: string;
  Name: string;
  Budget: number;
  Description: string;
  Tags: string[];
  StartsAt: Date;
  EndsAt: Date;
  PlanItems?: PlanItem[];
}
export class TripCollection extends ODataCollection<Trip> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Trip';
}