import { PersonSchema } from './person.schema';
import { PersonGender } from './persongender.enum';
import { Location } from './location.entity';
import { Photo } from './photo.entity';
import { Trip } from './trip.entity';

export interface Person {
  UserName: string;
  FirstName: string;
  LastName: string;
  Emails?: string[];
  AddressInfo?: Location[];
  Gender?: PersonGender;
  Concurrency?: number;
  Friends?: Person[];
  Trips?: Trip[];
  Photo?: Photo
}