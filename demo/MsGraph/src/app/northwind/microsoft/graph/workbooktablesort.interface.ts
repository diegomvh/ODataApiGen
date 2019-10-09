import { workbookSortField } from './workbooksortfield.interface';
import { entity } from './entity.interface';

export interface workbookTableSort extends entity {
  fields: workbookSortField[];
  matchCase: boolean;
  method: string
}
