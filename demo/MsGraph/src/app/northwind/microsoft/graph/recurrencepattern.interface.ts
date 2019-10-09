import { dayOfWeek } from './dayofweek.enum';
import { recurrencePatternType } from './recurrencepatterntype.enum';
import { weekIndex } from './weekindex.enum';

export interface recurrencePattern {
  type: recurrencePatternType;
  interval: number;
  month: number;
  dayOfMonth: number;
  daysOfWeek: dayOfWeek[];
  firstDayOfWeek: dayOfWeek;
  index: weekIndex
}
