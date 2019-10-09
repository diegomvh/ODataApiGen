import { attendeeBase } from './attendeebase.interface';
import { responseStatus } from './responsestatus.interface';

export interface attendee extends attendeeBase {
  status: responseStatus
}
