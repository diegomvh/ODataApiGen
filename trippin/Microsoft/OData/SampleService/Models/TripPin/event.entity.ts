import { EventSchema } from './event.schema';
import { EventLocation } from './eventlocation.entity';
import { PlanItem } from './planitem.entity';

export interface Event extends PlanItem {
  Description?: string;
  OccursAt: EventLocation
}