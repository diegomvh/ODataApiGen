import { EventLocationSchema } from './eventlocation.schema';
import { Location } from './location.entity';

export interface EventLocation extends Location {
  BuildingInfo?: string
}