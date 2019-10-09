import { entity } from './entity.interface';
import { workbookCommentReply } from './workbookcommentreply.interface';

export interface workbookComment extends entity {
  content: string;
  contentType: string;
  replies?: workbookCommentReply[]
}
