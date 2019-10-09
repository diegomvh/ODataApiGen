import { freeBusyStatus } from './freebusystatus.enum';
import { dateTimeTimeZone } from './datetimetimezone.interface';

export interface scheduleItem {
  start: dateTimeTimeZone;
  end: dateTimeTimeZone;
  isPrivate: boolean;
  status: freeBusyStatus;
  subject: string;
  location: string
}
