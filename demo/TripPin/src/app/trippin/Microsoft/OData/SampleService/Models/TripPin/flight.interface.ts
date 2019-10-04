import { Airline } from './airline.interface';
import { Airport } from './airport.interface';
import { PublicTransportation } from './publictransportation.interface';
 export interface Flight extends PublicTransportation {
  FlightNumber: string;
  From?: Airport;
  To?: Airport;
  Airline?: Airline
}
