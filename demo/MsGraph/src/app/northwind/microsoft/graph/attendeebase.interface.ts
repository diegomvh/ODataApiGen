import { attendeeType } from './attendeetype.enum';
import { recipient } from './recipient.interface';

export interface attendeeBase extends recipient {
  type: attendeeType
}
