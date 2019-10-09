import { identitySet } from './identityset.interface';
import { meetingInfo } from './meetinginfo.interface';

export interface organizerMeetingInfo extends meetingInfo {
  organizer: identitySet
}
