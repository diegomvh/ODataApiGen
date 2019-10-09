import { location } from './location.interface';
import { scoredEmailAddress } from './scoredemailaddress.interface';
import { phone } from './phone.interface';
import { website } from './website.interface';
import { personType } from './persontype.interface';
import { entity } from './entity.interface';

export interface person extends entity {
  displayName: string;
  givenName: string;
  surname: string;
  birthday: string;
  personNotes: string;
  isFavorite: boolean;
  scoredEmailAddresses: scoredEmailAddress[];
  phones: phone[];
  postalAddresses: location[];
  websites: website[];
  jobTitle: string;
  companyName: string;
  yomiCompany: string;
  department: string;
  officeLocation: string;
  profession: string;
  personType: personType;
  userPrincipalName: string;
  imAddress: string
}
