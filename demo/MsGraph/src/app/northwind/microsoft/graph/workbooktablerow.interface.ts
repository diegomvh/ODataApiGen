import { Json } from './json.interface';
import { entity } from './entity.interface';

export interface workbookTableRow extends entity {
  index: number;
  values: Json
}
