import { recipient } from './recipient.interface';
import { entity } from './entity.interface';
import { post } from './post.interface';

export interface conversationThread extends entity {
  toRecipients: recipient[];
  topic: string;
  hasAttachments: boolean;
  lastDeliveredDateTime: Date;
  uniqueSenders: string[];
  ccRecipients: recipient[];
  preview: string;
  isLocked: boolean;
  posts?: post[]
}
