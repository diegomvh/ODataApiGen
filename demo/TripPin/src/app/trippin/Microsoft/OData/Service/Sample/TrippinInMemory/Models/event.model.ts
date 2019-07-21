import { EventLocation, EventLocationCollection } from './eventlocation.model';
import { PlanItem, PlanItemCollection } from './planitem.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Event extends PlanItem {
  static schema = Od2Ts.Angular.Model.schema.extend({
    fields: [
      {name: 'OccursAt', type: 'EventLocation', constructor: EventLocation, required: true, collection: false},
      {name: 'Description', type: 'string', constructor: String, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  OccursAt: EventLocation;
  Description: string;
}
export class EventCollection extends ODataCollection<Event> {
  static Model = Event;
}