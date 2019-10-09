import { entity } from './entity.interface';
import { managedAppRegistration } from './managedappregistration.interface';
import { managedEBook } from './managedebook.interface';
import { mobileApp } from './mobileapp.interface';
import { mobileAppCategory } from './mobileappcategory.interface';
import { managedDeviceMobileAppConfiguration } from './manageddevicemobileappconfiguration.interface';
import { vppToken } from './vpptoken.interface';
import { managedAppPolicy } from './managedapppolicy.interface';
import { iosManagedAppProtection } from './iosmanagedappprotection.interface';
import { androidManagedAppProtection } from './androidmanagedappprotection.interface';
import { defaultManagedAppProtection } from './defaultmanagedappprotection.interface';
import { targetedManagedAppConfiguration } from './targetedmanagedappconfiguration.interface';
import { mdmWindowsInformationProtectionPolicy } from './mdmwindowsinformationprotectionpolicy.interface';
import { windowsInformationProtectionPolicy } from './windowsinformationprotectionpolicy.interface';
import { managedAppStatus } from './managedappstatus.interface';

export interface deviceAppManagement extends entity {
  microsoftStoreForBusinessLastSuccessfulSyncDateTime: Date;
  isEnabledForMicrosoftStoreForBusiness: boolean;
  microsoftStoreForBusinessLanguage: string;
  microsoftStoreForBusinessLastCompletedApplicationSyncTime: Date;
  managedEBooks?: managedEBook[];
  mobileApps?: mobileApp[];
  mobileAppCategories?: mobileAppCategory[];
  mobileAppConfigurations?: managedDeviceMobileAppConfiguration[];
  vppTokens?: vppToken[];
  managedAppPolicies?: managedAppPolicy[];
  iosManagedAppProtections?: iosManagedAppProtection[];
  androidManagedAppProtections?: androidManagedAppProtection[];
  defaultManagedAppProtections?: defaultManagedAppProtection[];
  targetedManagedAppConfigurations?: targetedManagedAppConfiguration[];
  mdmWindowsInformationProtectionPolicies?: mdmWindowsInformationProtectionPolicy[];
  windowsInformationProtectionPolicies?: windowsInformationProtectionPolicy[];
  managedAppRegistrations?: managedAppRegistration[];
  managedAppStatuses?: managedAppStatus[]
}
