import { CitySchema } from './city.schema';

export const LocationSchema = {
  Address: {type: 'string', nullable: false},
  City: {type: 'Microsoft.OData.SampleService.Models.TripPin.City', nullable: false}
};