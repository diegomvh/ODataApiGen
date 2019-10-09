import { automaticRepliesStatus } from './automaticrepliesstatus.enum';
import { externalAudienceScope } from './externalaudiencescope.enum';
import { dateTimeTimeZone } from './datetimetimezone.interface';

export interface automaticRepliesSetting {
  status: automaticRepliesStatus;
  externalAudience: externalAudienceScope;
  scheduledStartDateTime: dateTimeTimeZone;
  scheduledEndDateTime: dateTimeTimeZone;
  internalReplyMessage: string;
  externalReplyMessage: string
}
