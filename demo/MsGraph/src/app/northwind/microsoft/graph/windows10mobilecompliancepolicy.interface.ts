import { requiredPasswordType } from './requiredpasswordtype.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface windows10MobileCompliancePolicy extends deviceCompliancePolicy {
  passwordRequired: boolean;
  passwordBlockSimple: boolean;
  passwordMinimumLength: number;
  passwordMinimumCharacterSetCount: number;
  passwordRequiredType: requiredPasswordType;
  passwordPreviousPasswordBlockCount: number;
  passwordExpirationDays: number;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordRequireToUnlockFromIdle: boolean;
  osMinimumVersion: string;
  osMaximumVersion: string;
  earlyLaunchAntiMalwareDriverEnabled: boolean;
  bitLockerEnabled: boolean;
  secureBootEnabled: boolean;
  codeIntegrityEnabled: boolean;
  storageRequireEncryption: boolean
}
