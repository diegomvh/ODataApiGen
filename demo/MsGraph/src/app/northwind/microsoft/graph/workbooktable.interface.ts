import { entity } from './entity.interface';
import { workbookWorksheet } from './workbookworksheet.interface';
import { workbookTableColumn } from './workbooktablecolumn.interface';
import { workbookTableRow } from './workbooktablerow.interface';
import { workbookTableSort } from './workbooktablesort.interface';

export interface workbookTable extends entity {
  highlightFirstColumn: boolean;
  highlightLastColumn: boolean;
  legacyId: string;
  name: string;
  showBandedColumns: boolean;
  showBandedRows: boolean;
  showFilterButton: boolean;
  showHeaders: boolean;
  showTotals: boolean;
  style: string;
  columns?: workbookTableColumn[];
  rows?: workbookTableRow[];
  sort?: workbookTableSort;
  worksheet?: workbookWorksheet
}
