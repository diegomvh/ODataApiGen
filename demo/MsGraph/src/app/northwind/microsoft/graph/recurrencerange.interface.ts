import { recurrenceRangeType } from './recurrencerangetype.enum';

export interface recurrenceRange {
  type: recurrenceRangeType;
  startDate: any;
  endDate: any;
  recurrenceTimeZone: string;
  numberOfOccurrences: number
}
