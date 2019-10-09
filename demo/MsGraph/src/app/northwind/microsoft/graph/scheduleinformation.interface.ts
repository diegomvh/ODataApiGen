import { workingHours } from './workinghours.interface';
import { scheduleItem } from './scheduleitem.interface';
import { freeBusyError } from './freebusyerror.interface';

export interface scheduleInformation {
  scheduleId: string;
  scheduleItems: scheduleItem[];
  availabilityView: string;
  error: freeBusyError;
  workingHours: workingHours
}
