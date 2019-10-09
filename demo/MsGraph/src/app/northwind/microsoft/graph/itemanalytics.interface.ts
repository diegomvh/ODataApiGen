import { entity } from './entity.interface';
import { itemActivityStat } from './itemactivitystat.interface';

export interface itemAnalytics extends entity {
  itemActivityStats?: itemActivityStat[];
  allTime?: itemActivityStat;
  lastSevenDays?: itemActivityStat
}
