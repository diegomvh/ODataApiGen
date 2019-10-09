import { androidRequiredPasswordType } from './androidrequiredpasswordtype.enum';
import { deviceThreatProtectionLevel } from './devicethreatprotectionlevel.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface androidCompliancePolicy extends deviceCompliancePolicy {
  passwordRequired: boolean;
  passwordMinimumLength: number;
  passwordRequiredType: androidRequiredPasswordType;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordExpirationDays: number;
  passwordPreviousPasswordBlockCount: number;
  securityPreventInstallAppsFromUnknownSources: boolean;
  securityDisableUsbDebugging: boolean;
  securityRequireVerifyApps: boolean;
  deviceThreatProtectionEnabled: boolean;
  deviceThreatProtectionRequiredSecurityLevel: deviceThreatProtectionLevel;
  securityBlockJailbrokenDevices: boolean;
  osMinimumVersion: string;
  osMaximumVersion: string;
  minAndroidSecurityPatchLevel: string;
  storageRequireEncryption: boolean;
  securityRequireSafetyNetAttestationBasicIntegrity: boolean;
  securityRequireSafetyNetAttestationCertifiedDevice: boolean;
  securityRequireGooglePlayServices: boolean;
  securityRequireUpToDateSecurityProviders: boolean;
  securityRequireCompanyPortalAppIntegrity: boolean
}
