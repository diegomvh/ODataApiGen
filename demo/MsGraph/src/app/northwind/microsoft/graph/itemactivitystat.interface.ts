import { itemActionStat } from './itemactionstat.interface';
import { incompleteData } from './incompletedata.interface';
import { entity } from './entity.interface';
import { itemActivity } from './itemactivity.interface';

export interface itemActivityStat extends entity {
  startDateTime: Date;
  endDateTime: Date;
  access: itemActionStat;
  create: itemActionStat;
  delete: itemActionStat;
  edit: itemActionStat;
  move: itemActionStat;
  isTrending: boolean;
  incompleteData: incompleteData;
  activities?: itemActivity[]
}
