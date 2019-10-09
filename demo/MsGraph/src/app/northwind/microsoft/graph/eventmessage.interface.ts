import { meetingMessageType } from './meetingmessagetype.enum';
import { message } from './message.interface';
import { event } from './event.interface';

export interface eventMessage extends message {
  meetingMessageType: meetingMessageType;
  event?: event
}
