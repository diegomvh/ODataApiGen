import { AirlineSchema } from './airline.schema';
import { AirportSchema } from './airport.schema';
import { PublicTransportationSchema } from './publictransportation.schema';

export const FlightSchema = Object.assign({}, PublicTransportationSchema, {
  FlightNumber: {type: 'string', nullable: false},
  From: {type: 'Microsoft.OData.SampleService.Models.TripPin.Airport', navigation: true},
  To: {type: 'Microsoft.OData.SampleService.Models.TripPin.Airport', navigation: true},
  Airline: {type: 'Microsoft.OData.SampleService.Models.TripPin.Airline', navigation: true}
});