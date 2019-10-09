import { dayOfWeek } from './dayofweek.enum';
import { timeZoneBase } from './timezonebase.interface';

export interface workingHours {
  daysOfWeek: dayOfWeek[];
  startTime: any;
  endTime: any;
  timeZone: timeZoneBase
}
