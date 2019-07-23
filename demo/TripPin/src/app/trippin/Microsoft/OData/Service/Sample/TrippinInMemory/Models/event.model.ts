import { EventLocation } from './eventlocation.model';
import { PlanItem, PlanItemCollection } from './planitem.model';
import { Schema, Model, ODataModel, ODataCollection } from 'angular-odata';
export class Event extends PlanItem {
  static type = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Event';
  static schema = PlanItem.schema.extend({
    fields: [
      {name: 'OccursAt', type: 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.EventLocation', required: true, collection: false},
      {name: 'Description', type: 'String', required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  OccursAt: EventLocation;
  Description: string;
}
export class EventCollection extends ODataCollection<Event> {
  static model = 'Microsoft.OData.Service.Sample.TrippinInMemory.Models.Event';
}