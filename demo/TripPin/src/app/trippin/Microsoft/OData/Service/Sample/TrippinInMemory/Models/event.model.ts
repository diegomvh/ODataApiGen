import { PlanItem, PlanItemCollection } from './planitem.model';
import { EventLocation, EventLocationCollection } from './eventlocation.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Event extends PlanItem {
  OccursAt?: EventLocation;
  Description?: string;
  private static _meta: ODataModelOptions<Event> = new ODataModelOptions<Event>({
    fields: [
      {name: 'OccursAt', type: 'EventLocation', required: false, length: 0, collection: false},
      {name: 'Description', type: 'string', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return Event._meta; }
}

export class EventCollection extends ODataCollection<Event> {
}