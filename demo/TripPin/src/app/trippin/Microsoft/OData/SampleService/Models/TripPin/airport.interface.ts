import { AirportLocation } from './airportlocation.interface';

export interface Airport {
  IcaoCode: string;
  Name: string;
  IataCode: string;
  Location: AirportLocation;
}