import { entity } from './entity.interface';
import { outlookCategory } from './outlookcategory.interface';

export interface outlookUser extends entity {
  masterCategories?: outlookCategory[]
}
