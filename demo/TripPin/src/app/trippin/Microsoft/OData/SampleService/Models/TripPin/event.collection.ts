import { ODataCollection } from 'angular-odata';

import { Event } from './event.model';

export class EventCollection extends ODataCollection<Event> {
  static model = Event;
}
