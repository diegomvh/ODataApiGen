import { recipientScopeType } from './recipientscopetype.enum';
import { recipient } from './recipient.interface';
import { emailAddress } from './emailaddress.interface';
import { automaticRepliesMailTips } from './automaticrepliesmailtips.interface';
import { mailTipsError } from './mailtipserror.interface';

export interface mailTips {
  emailAddress: emailAddress;
  automaticReplies: automaticRepliesMailTips;
  mailboxFull: boolean;
  customMailTip: string;
  externalMemberCount: number;
  totalMemberCount: number;
  deliveryRestricted: boolean;
  isModerated: boolean;
  recipientScope: recipientScopeType;
  recipientSuggestions: recipient[];
  maxMessageSize: number;
  error: mailTipsError
}
