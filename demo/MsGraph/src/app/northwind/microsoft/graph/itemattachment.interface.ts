import { outlookItem } from './outlookitem.interface';
import { attachment } from './attachment.interface';

export interface itemAttachment extends attachment {
  item?: outlookItem
}
