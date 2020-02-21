import { LocationSchema } from './location.schema';
import { City } from './city.entity';

export interface Location {
  Address: string;
  City: City
}