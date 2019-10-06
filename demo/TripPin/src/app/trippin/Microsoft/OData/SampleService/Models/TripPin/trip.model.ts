import { ODataModel, Schema } from 'angular-odata';

import { Photo } from './photo.model';
import { PlanItem } from './planitem.model';
import { PhotoCollection } from './photo.collection';
import { PlanItemCollection } from './planitem.collection';

export class Trip extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      {name: 'TripId'}
    ],
    fields: [
      {name: 'TripId', type: 'Number', required: true},
      {name: 'ShareId', type: 'String', required: true},
      {name: 'Description', type: 'String', required: true},
      {name: 'Name', type: 'String', required: true},
      {name: 'Budget', type: 'Number', required: true},
      {name: 'StartsAt', type: 'Date', required: true},
      {name: 'EndsAt', type: 'Date', required: true},
      {name: 'Tags', type: 'String', required: true, collection: true},
      {name: 'Photos', type: 'Microsoft.OData.SampleService.Models.TripPin.PhotoCollection', navigation: true, collection: true},
      {name: 'PlanItems', type: 'Microsoft.OData.SampleService.Models.TripPin.PlanItemCollection', navigation: true, collection: true}
    ]
  });
  TripId: number;
  ShareId: string;
  Description: string;
  Name: string;
  Budget: number;
  StartsAt: Date;
  EndsAt: Date;
  Tags: string[];
  Photos?: PhotoCollection;
  PlanItems?: PlanItemCollection
}