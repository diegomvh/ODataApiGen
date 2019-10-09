import { dateTimeTimeZone } from './datetimetimezone.interface';
import { location } from './location.interface';

export interface reminder {
  eventId: string;
  eventStartTime: dateTimeTimeZone;
  eventEndTime: dateTimeTimeZone;
  changeKey: string;
  eventSubject: string;
  eventLocation: location;
  eventWebLink: string;
  reminderFireTime: dateTimeTimeZone
}
