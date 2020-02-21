import { AirportLocationSchema } from './airportlocation.schema';

export const AirportSchema = {
  IcaoCode: {type: 'string', key: true, ref: 'IcaoCode', nullable: false},
  Name: {type: 'string', nullable: false},
  IataCode: {type: 'string', nullable: false},
  Location: {type: 'Microsoft.OData.SampleService.Models.TripPin.AirportLocation', nullable: false}
};