import { PersonGender } from './persongender.enum';
import { LocationSchema } from './location.schema';
import { PhotoSchema } from './photo.schema';
import { TripSchema } from './trip.schema';

export const PersonSchema = {
  UserName: {type: 'string', key: true, ref: 'UserName', nullable: false},
  FirstName: {type: 'string', nullable: false},
  LastName: {type: 'string', nullable: false},
  Emails: {type: 'string', collection: true},
  AddressInfo: {type: 'Microsoft.OData.SampleService.Models.TripPin.Location', collection: true},
  Gender: {type: 'Microsoft.OData.SampleService.Models.TripPin.PersonGender', flags: false},
  Concurrency: {type: 'number', nullable: false},
  Friends: {type: 'Microsoft.OData.SampleService.Models.TripPin.Person', collection: true, navigation: true},
  Trips: {type: 'Microsoft.OData.SampleService.Models.TripPin.Trip', collection: true, navigation: true},
  Photo: {type: 'Microsoft.OData.SampleService.Models.TripPin.Photo', navigation: true}
};