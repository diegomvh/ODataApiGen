import { dayOfWeek } from './dayofweek.enum';

export interface standardTimeZoneOffset {
  time: any;
  dayOccurrence: number;
  dayOfWeek: dayOfWeek;
  month: number;
  year: number
}
