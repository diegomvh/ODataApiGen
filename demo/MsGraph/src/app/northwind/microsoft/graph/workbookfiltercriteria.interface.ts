import { Json } from './json.interface';
import { workbookIcon } from './workbookicon.interface';

export interface workbookFilterCriteria {
  color: string;
  criterion1: string;
  criterion2: string;
  dynamicCriteria: string;
  filterOn: string;
  icon: workbookIcon;
  operator: string;
  values: Json
}
