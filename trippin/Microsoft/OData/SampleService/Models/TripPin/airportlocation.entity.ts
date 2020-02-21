import { AirportLocationSchema } from './airportlocation.schema';
import { Location } from './location.entity';

export interface AirportLocation extends Location {
  Loc: any
}