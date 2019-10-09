import { entity } from './entity.interface';
import { workbookNamedItem } from './workbooknameditem.interface';
import { workbookTable } from './workbooktable.interface';
import { workbookChart } from './workbookchart.interface';
import { workbookPivotTable } from './workbookpivottable.interface';
import { workbookWorksheetProtection } from './workbookworksheetprotection.interface';

export interface workbookWorksheet extends entity {
  name: string;
  position: number;
  visibility: string;
  charts?: workbookChart[];
  names?: workbookNamedItem[];
  pivotTables?: workbookPivotTable[];
  protection?: workbookWorksheetProtection;
  tables?: workbookTable[]
}
