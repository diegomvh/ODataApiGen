import { Json } from './json.interface';
import { entity } from './entity.interface';

export interface workbookRangeView extends entity {
  cellAddresses: Json;
  columnCount: number;
  formulas: Json;
  formulasLocal: Json;
  formulasR1C1: Json;
  index: number;
  numberFormat: Json;
  rowCount: number;
  text: Json;
  valueTypes: Json;
  values: Json;
  rows?: workbookRangeView[]
}
