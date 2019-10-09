import { mdmAuthority } from './mdmauthority.enum';
import { assignedPlan } from './assignedplan.interface';
import { provisionedPlan } from './provisionedplan.interface';
import { privacyProfile } from './privacyprofile.interface';
import { verifiedDomain } from './verifieddomain.interface';
import { directoryObject } from './directoryobject.interface';
import { extension } from './extension.interface';

export interface organization extends directoryObject {
  assignedPlans: assignedPlan[];
  businessPhones: string[];
  city: string;
  country: string;
  countryLetterCode: string;
  createdDateTime: Date;
  displayName: string;
  marketingNotificationEmails: string[];
  onPremisesLastSyncDateTime: Date;
  onPremisesSyncEnabled: boolean;
  postalCode: string;
  preferredLanguage: string;
  privacyProfile: privacyProfile;
  provisionedPlans: provisionedPlan[];
  securityComplianceNotificationMails: string[];
  securityComplianceNotificationPhones: string[];
  state: string;
  street: string;
  technicalNotificationMails: string[];
  verifiedDomains: verifiedDomain[];
  mobileDeviceManagementAuthority: mdmAuthority;
  extensions?: extension[]
}
