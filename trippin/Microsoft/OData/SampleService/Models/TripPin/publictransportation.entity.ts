import { PublicTransportationSchema } from './publictransportation.schema';
import { PlanItem } from './planitem.entity';

export interface PublicTransportation extends PlanItem {
  SeatNumber?: string
}