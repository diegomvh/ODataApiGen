import { emailAddress } from './emailaddress.interface';
import { physicalAddress } from './physicaladdress.interface';
import { outlookItem } from './outlookitem.interface';
import { profilePhoto } from './profilephoto.interface';
import { extension } from './extension.interface';
import { singleValueLegacyExtendedProperty } from './singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './multivaluelegacyextendedproperty.interface';

export interface contact extends outlookItem {
  parentFolderId: string;
  birthday: Date;
  fileAs: string;
  displayName: string;
  givenName: string;
  initials: string;
  middleName: string;
  nickName: string;
  surname: string;
  title: string;
  yomiGivenName: string;
  yomiSurname: string;
  yomiCompanyName: string;
  generation: string;
  emailAddresses: emailAddress[];
  imAddresses: string[];
  jobTitle: string;
  companyName: string;
  department: string;
  officeLocation: string;
  profession: string;
  businessHomePage: string;
  assistantName: string;
  manager: string;
  homePhones: string[];
  mobilePhone: string;
  businessPhones: string[];
  homeAddress: physicalAddress;
  businessAddress: physicalAddress;
  otherAddress: physicalAddress;
  spouseName: string;
  personalNotes: string;
  children: string[];
  singleValueExtendedProperties?: singleValueLegacyExtendedProperty[];
  multiValueExtendedProperties?: multiValueLegacyExtendedProperty[];
  photo?: profilePhoto;
  extensions?: extension[]
}
