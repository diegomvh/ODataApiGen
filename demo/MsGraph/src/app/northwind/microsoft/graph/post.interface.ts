import { recipient } from './recipient.interface';
import { itemBody } from './itembody.interface';
import { outlookItem } from './outlookitem.interface';
import { extension } from './extension.interface';
import { singleValueLegacyExtendedProperty } from './singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './multivaluelegacyextendedproperty.interface';
import { attachment } from './attachment.interface';

export interface post extends outlookItem {
  body: itemBody;
  receivedDateTime: Date;
  hasAttachments: boolean;
  from: recipient;
  sender: recipient;
  conversationThreadId: string;
  newParticipants: recipient[];
  conversationId: string;
  inReplyTo?: post;
  singleValueExtendedProperties?: singleValueLegacyExtendedProperty[];
  multiValueExtendedProperties?: multiValueLegacyExtendedProperty[];
  extensions?: extension[];
  attachments?: attachment[]
}
