import { entity } from './entity.interface';
import { workbookWorksheet } from './workbookworksheet.interface';

export interface workbookPivotTable extends entity {
  name: string;
  worksheet?: workbookWorksheet
}
