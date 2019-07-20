import { PlanItem, PlanItemCollection } from './planitem.model';
import { EventLocation, EventLocationCollection } from './eventlocation.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const EventSchema = new ODataModelSchema({
  fields: [
    {name: 'OccursAt', type: 'EventLocation', required: false, length: 0, collection: false},
      {name: 'Description', type: 'string', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class Event extends PlanItem {
  OccursAt?: EventLocation;
  Description?: string;
  protected schema: ODataModelSchema = EventSchema;
}

export class EventCollection extends ODataCollection<Event> {
}