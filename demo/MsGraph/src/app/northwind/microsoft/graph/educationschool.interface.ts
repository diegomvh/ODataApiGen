import { physicalAddress } from './physicaladdress.interface';
import { identitySet } from './identityset.interface';
import { educationClass } from './educationclass.interface';
import { educationOrganization } from './educationorganization.interface';
import { educationUser } from './educationuser.interface';

export interface educationSchool extends educationOrganization {
  principalEmail: string;
  principalName: string;
  externalPrincipalId: string;
  lowestGrade: string;
  highestGrade: string;
  schoolNumber: string;
  externalId: string;
  phone: string;
  fax: string;
  createdBy: identitySet;
  address: physicalAddress;
  classes?: educationClass[];
  users?: educationUser[]
}
