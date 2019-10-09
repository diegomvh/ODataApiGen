import { educationUserRole } from './educationuserrole.enum';
import { educationExternalSource } from './educationexternalsource.enum';
import { assignedLicense } from './assignedlicense.interface';
import { assignedPlan } from './assignedplan.interface';
import { passwordProfile } from './passwordprofile.interface';
import { provisionedPlan } from './provisionedplan.interface';
import { physicalAddress } from './physicaladdress.interface';
import { identitySet } from './identityset.interface';
import { educationStudent } from './educationstudent.interface';
import { educationTeacher } from './educationteacher.interface';
import { entity } from './entity.interface';
import { user } from './user.interface';
import { educationClass } from './educationclass.interface';
import { educationSchool } from './educationschool.interface';

export interface educationUser extends entity {
  primaryRole: educationUserRole;
  middleName: string;
  externalSource: educationExternalSource;
  residenceAddress: physicalAddress;
  mailingAddress: physicalAddress;
  student: educationStudent;
  teacher: educationTeacher;
  createdBy: identitySet;
  accountEnabled: boolean;
  assignedLicenses: assignedLicense[];
  assignedPlans: assignedPlan[];
  businessPhones: string[];
  department: string;
  displayName: string;
  givenName: string;
  mail: string;
  mailNickname: string;
  mobilePhone: string;
  passwordPolicies: string;
  passwordProfile: passwordProfile;
  officeLocation: string;
  preferredLanguage: string;
  provisionedPlans: provisionedPlan[];
  refreshTokensValidFromDateTime: Date;
  showInAddressList: boolean;
  surname: string;
  usageLocation: string;
  userPrincipalName: string;
  userType: string;
  schools?: educationSchool[];
  classes?: educationClass[];
  user?: user
}
