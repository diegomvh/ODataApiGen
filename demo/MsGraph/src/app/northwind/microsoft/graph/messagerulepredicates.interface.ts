import { importance } from './importance.enum';
import { sensitivity } from './sensitivity.enum';
import { messageActionFlag } from './messageactionflag.enum';
import { recipient } from './recipient.interface';
import { sizeRange } from './sizerange.interface';

export interface messageRulePredicates {
  categories: string[];
  subjectContains: string[];
  bodyContains: string[];
  bodyOrSubjectContains: string[];
  senderContains: string[];
  recipientContains: string[];
  headerContains: string[];
  messageActionFlag: messageActionFlag;
  importance: importance;
  sensitivity: sensitivity;
  fromAddresses: recipient[];
  sentToAddresses: recipient[];
  sentToMe: boolean;
  sentOnlyToMe: boolean;
  sentCcMe: boolean;
  sentToOrCcMe: boolean;
  notSentToMe: boolean;
  hasAttachments: boolean;
  isApprovalRequest: boolean;
  isAutomaticForward: boolean;
  isAutomaticReply: boolean;
  isEncrypted: boolean;
  isMeetingRequest: boolean;
  isMeetingResponse: boolean;
  isNonDeliveryReport: boolean;
  isPermissionControlled: boolean;
  isReadReceipt: boolean;
  isSigned: boolean;
  isVoicemail: boolean;
  withinSizeRange: sizeRange
}
