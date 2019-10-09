import { importance } from './importance.enum';
import { inferenceClassificationType } from './inferenceclassificationtype.enum';
import { recipient } from './recipient.interface';
import { internetMessageHeader } from './internetmessageheader.interface';
import { itemBody } from './itembody.interface';
import { followupFlag } from './followupflag.interface';
import { outlookItem } from './outlookitem.interface';
import { extension } from './extension.interface';
import { singleValueLegacyExtendedProperty } from './singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './multivaluelegacyextendedproperty.interface';
import { attachment } from './attachment.interface';

export interface message extends outlookItem {
  receivedDateTime: Date;
  sentDateTime: Date;
  hasAttachments: boolean;
  internetMessageId: string;
  internetMessageHeaders: internetMessageHeader[];
  subject: string;
  body: itemBody;
  bodyPreview: string;
  importance: importance;
  parentFolderId: string;
  sender: recipient;
  from: recipient;
  toRecipients: recipient[];
  ccRecipients: recipient[];
  bccRecipients: recipient[];
  replyTo: recipient[];
  conversationId: string;
  uniqueBody: itemBody;
  isDeliveryReceiptRequested: boolean;
  isReadReceiptRequested: boolean;
  isRead: boolean;
  isDraft: boolean;
  webLink: string;
  inferenceClassification: inferenceClassificationType;
  flag: followupFlag;
  singleValueExtendedProperties?: singleValueLegacyExtendedProperty[];
  multiValueExtendedProperties?: multiValueLegacyExtendedProperty[];
  attachments?: attachment[];
  extensions?: extension[]
}
