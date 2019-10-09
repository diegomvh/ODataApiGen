import { Json } from './json.interface';
import { entity } from './entity.interface';
import { workbookFilter } from './workbookfilter.interface';

export interface workbookTableColumn extends entity {
  index: number;
  name: string;
  values: Json;
  filter?: workbookFilter
}
