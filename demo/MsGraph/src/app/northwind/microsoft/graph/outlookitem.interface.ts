import { entity } from './entity.interface';

export interface outlookItem extends entity {
  createdDateTime: Date;
  lastModifiedDateTime: Date;
  changeKey: string;
  categories: string[]
}
