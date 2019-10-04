import { PersonGender } from './persongender.enum';
import { Location } from './location.interface';
import { Photo } from './photo.interface';
import { Trip } from './trip.interface';
 export interface Person {
  UserName: string;
  FirstName: string;
  LastName: string;
  Emails: string[];
  AddressInfo: Location[];
  Gender: PersonGender;
  Concurrency: number;
  Friends?: Person[];
  Trips?: Trip[];
  Photo?: Photo
}
