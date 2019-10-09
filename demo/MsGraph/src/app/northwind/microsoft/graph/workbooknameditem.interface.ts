import { Json } from './json.interface';
import { entity } from './entity.interface';
import { workbookWorksheet } from './workbookworksheet.interface';

export interface workbookNamedItem extends entity {
  comment: string;
  name: string;
  scope: string;
  type: string;
  value: Json;
  visible: boolean;
  worksheet?: workbookWorksheet
}
