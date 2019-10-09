import { freeBusyStatus } from './freebusystatus.enum';
import { attendeeBase } from './attendeebase.interface';

export interface attendeeAvailability {
  attendee: attendeeBase;
  availability: freeBusyStatus
}
