import { entity } from './entity.interface';

export interface workbookRangeFont extends entity {
  bold: boolean;
  color: string;
  italic: boolean;
  name: string;
  size: number;
  underline: string
}
