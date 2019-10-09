import { onenotePatchInsertPosition } from './onenotepatchinsertposition.enum';
import { onenotePatchActionType } from './onenotepatchactiontype.enum';

export interface onenotePatchContentCommand {
  action: onenotePatchActionType;
  target: string;
  content: string;
  position: onenotePatchInsertPosition
}
