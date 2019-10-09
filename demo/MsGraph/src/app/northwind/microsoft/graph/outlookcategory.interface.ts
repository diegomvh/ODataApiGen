import { categoryColor } from './categorycolor.enum';
import { entity } from './entity.interface';

export interface outlookCategory extends entity {
  displayName: string;
  color: categoryColor
}
