import { dateTimeTimeZone } from './datetimetimezone.interface';
import { localeInfo } from './localeinfo.interface';

export interface automaticRepliesMailTips {
  message: string;
  messageLanguage: localeInfo;
  scheduledStartTime: dateTimeTimeZone;
  scheduledEndTime: dateTimeTimeZone
}
