import { entity } from './entity.interface';
import { workbookApplication } from './workbookapplication.interface';
import { workbookNamedItem } from './workbooknameditem.interface';
import { workbookTable } from './workbooktable.interface';
import { workbookWorksheet } from './workbookworksheet.interface';
import { workbookComment } from './workbookcomment.interface';
import { workbookFunctions } from './workbookfunctions.interface';

export interface workbook extends entity {
  application?: workbookApplication;
  names?: workbookNamedItem[];
  tables?: workbookTable[];
  worksheets?: workbookWorksheet[];
  comments?: workbookComment[];
  functions?: workbookFunctions
}
