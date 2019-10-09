import { attachment } from './attachment.interface';

export interface fileAttachment extends attachment {
  contentId: string;
  contentLocation: string;
  contentBytes: string
}
