import { ODataCollection } from 'angular-odata';

import { EventLocation } from './eventlocation.model';

export class EventLocationCollection extends ODataCollection<EventLocation> {
  static model = EventLocation;
}
