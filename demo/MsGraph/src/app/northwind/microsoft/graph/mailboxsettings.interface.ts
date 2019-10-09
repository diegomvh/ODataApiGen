import { automaticRepliesSetting } from './automaticrepliessetting.interface';
import { localeInfo } from './localeinfo.interface';
import { workingHours } from './workinghours.interface';

export interface mailboxSettings {
  automaticRepliesSetting: automaticRepliesSetting;
  archiveFolder: string;
  timeZone: string;
  language: localeInfo;
  workingHours: workingHours;
  dateFormat: string;
  timeFormat: string
}
