import { recurrencePattern } from './recurrencepattern.interface';
import { recurrenceRange } from './recurrencerange.interface';

export interface patternedRecurrence {
  pattern: recurrencePattern;
  range: recurrenceRange
}
