import { followupFlagStatus } from './followupflagstatus.enum';
import { dateTimeTimeZone } from './datetimetimezone.interface';

export interface followupFlag {
  completedDateTime: dateTimeTimeZone;
  dueDateTime: dateTimeTimeZone;
  startDateTime: dateTimeTimeZone;
  flagStatus: followupFlagStatus
}
