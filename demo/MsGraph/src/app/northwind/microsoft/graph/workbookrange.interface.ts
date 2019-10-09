import { Json } from './json.interface';
import { entity } from './entity.interface';
import { workbookWorksheet } from './workbookworksheet.interface';
import { workbookRangeFormat } from './workbookrangeformat.interface';
import { workbookRangeSort } from './workbookrangesort.interface';

export interface workbookRange extends entity {
  address: string;
  addressLocal: string;
  cellCount: number;
  columnCount: number;
  columnHidden: boolean;
  columnIndex: number;
  formulas: Json;
  formulasLocal: Json;
  formulasR1C1: Json;
  hidden: boolean;
  numberFormat: Json;
  rowCount: number;
  rowHidden: boolean;
  rowIndex: number;
  text: Json;
  valueTypes: Json;
  values: Json;
  format?: workbookRangeFormat;
  sort?: workbookRangeSort;
  worksheet?: workbookWorksheet
}
