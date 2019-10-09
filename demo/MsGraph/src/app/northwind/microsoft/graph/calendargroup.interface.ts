import { entity } from './entity.interface';
import { calendar } from './calendar.interface';

export interface calendarGroup extends entity {
  name: string;
  classId: string;
  changeKey: string;
  calendars?: calendar[]
}
