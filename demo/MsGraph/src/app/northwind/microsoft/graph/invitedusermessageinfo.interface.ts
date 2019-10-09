import { recipient } from './recipient.interface';

export interface invitedUserMessageInfo {
  ccRecipients: recipient[];
  messageLanguage: string;
  customizedMessageBody: string
}
