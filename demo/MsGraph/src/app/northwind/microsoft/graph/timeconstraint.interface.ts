import { activityDomain } from './activitydomain.enum';
import { timeSlot } from './timeslot.interface';

export interface timeConstraint {
  activityDomain: activityDomain;
  timeSlots: timeSlot[]
}
