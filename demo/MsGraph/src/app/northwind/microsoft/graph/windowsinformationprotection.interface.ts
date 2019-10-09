import { windowsInformationProtectionEnforcementLevel } from './windowsinformationprotectionenforcementlevel.enum';
import { windowsInformationProtectionResourceCollection } from './windowsinformationprotectionresourcecollection.interface';
import { windowsInformationProtectionDataRecoveryCertificate } from './windowsinformationprotectiondatarecoverycertificate.interface';
import { windowsInformationProtectionApp } from './windowsinformationprotectionapp.interface';
import { windowsInformationProtectionProxiedDomainCollection } from './windowsinformationprotectionproxieddomaincollection.interface';
import { windowsInformationProtectionIPRangeCollection } from './windowsinformationprotectioniprangecollection.interface';
import { managedAppPolicy } from './managedapppolicy.interface';
import { targetedManagedAppPolicyAssignment } from './targetedmanagedapppolicyassignment.interface';
import { windowsInformationProtectionAppLockerFile } from './windowsinformationprotectionapplockerfile.interface';

export interface windowsInformationProtection extends managedAppPolicy {
  enforcementLevel: windowsInformationProtectionEnforcementLevel;
  enterpriseDomain: string;
  enterpriseProtectedDomainNames: windowsInformationProtectionResourceCollection[];
  protectionUnderLockConfigRequired: boolean;
  dataRecoveryCertificate: windowsInformationProtectionDataRecoveryCertificate;
  revokeOnUnenrollDisabled: boolean;
  rightsManagementServicesTemplateId: string;
  azureRightsManagementServicesAllowed: boolean;
  iconsVisible: boolean;
  protectedApps: windowsInformationProtectionApp[];
  exemptApps: windowsInformationProtectionApp[];
  enterpriseNetworkDomainNames: windowsInformationProtectionResourceCollection[];
  enterpriseProxiedDomains: windowsInformationProtectionProxiedDomainCollection[];
  enterpriseIPRanges: windowsInformationProtectionIPRangeCollection[];
  enterpriseIPRangesAreAuthoritative: boolean;
  enterpriseProxyServers: windowsInformationProtectionResourceCollection[];
  enterpriseInternalProxyServers: windowsInformationProtectionResourceCollection[];
  enterpriseProxyServersAreAuthoritative: boolean;
  neutralDomainResources: windowsInformationProtectionResourceCollection[];
  indexingEncryptedStoresOrItemsBlocked: boolean;
  smbAutoEncryptedFileExtensions: windowsInformationProtectionResourceCollection[];
  isAssigned: boolean;
  protectedAppLockerFiles?: windowsInformationProtectionAppLockerFile[];
  exemptAppLockerFiles?: windowsInformationProtectionAppLockerFile[];
  assignments?: targetedManagedAppPolicyAssignment[]
}
