import { requiredPasswordType } from './requiredpasswordtype.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface windows10CompliancePolicy extends deviceCompliancePolicy {
  passwordRequired: boolean;
  passwordBlockSimple: boolean;
  passwordRequiredToUnlockFromIdle: boolean;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinimumCharacterSetCount: number;
  passwordRequiredType: requiredPasswordType;
  passwordPreviousPasswordBlockCount: number;
  requireHealthyDeviceReport: boolean;
  osMinimumVersion: string;
  osMaximumVersion: string;
  mobileOsMinimumVersion: string;
  mobileOsMaximumVersion: string;
  earlyLaunchAntiMalwareDriverEnabled: boolean;
  bitLockerEnabled: boolean;
  secureBootEnabled: boolean;
  codeIntegrityEnabled: boolean;
  storageRequireEncryption: boolean
}
