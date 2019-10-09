import { importance } from './importance.enum';
import { recipient } from './recipient.interface';

export interface messageRuleActions {
  moveToFolder: string;
  copyToFolder: string;
  delete: boolean;
  permanentDelete: boolean;
  markAsRead: boolean;
  markImportance: importance;
  forwardTo: recipient[];
  forwardAsAttachmentTo: recipient[];
  redirectTo: recipient[];
  assignCategories: string[];
  stopProcessingRules: boolean
}
