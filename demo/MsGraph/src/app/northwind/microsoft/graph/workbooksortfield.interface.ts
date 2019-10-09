import { workbookIcon } from './workbookicon.interface';

export interface workbookSortField {
  ascending: boolean;
  color: string;
  dataOption: string;
  icon: workbookIcon;
  key: number;
  sortOn: string
}
