import { AirportSchema } from './airport.schema';
import { AirportLocation } from './airportlocation.entity';

export interface Airport {
  IcaoCode: string;
  Name: string;
  IataCode: string;
  Location: AirportLocation
}