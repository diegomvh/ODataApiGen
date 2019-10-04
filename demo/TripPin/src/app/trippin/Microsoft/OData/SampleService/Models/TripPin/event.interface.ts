import { EventLocation } from './eventlocation.interface';
import { PlanItem } from './planitem.interface';
 export interface Event extends PlanItem {
  Description: string;
  OccursAt: EventLocation
}
