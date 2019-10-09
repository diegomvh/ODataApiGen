import { entity } from './entity.interface';
import { conversationThread } from './conversationthread.interface';

export interface conversation extends entity {
  topic: string;
  hasAttachments: boolean;
  lastDeliveredDateTime: Date;
  uniqueSenders: string[];
  preview: string;
  threads?: conversationThread[]
}
