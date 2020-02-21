import { FlightSchema } from './flight.schema';
import { Airline } from './airline.entity';
import { Airport } from './airport.entity';
import { PublicTransportation } from './publictransportation.entity';

export interface Flight extends PublicTransportation {
  FlightNumber: string;
  From?: Airport;
  To?: Airport;
  Airline?: Airline
}