import { entity } from './entity.interface';

export interface workbookCommentReply extends entity {
  content: string;
  contentType: string
}
