import { requiredPasswordType } from './requiredpasswordtype.enum';
import { deviceThreatProtectionLevel } from './devicethreatprotectionlevel.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface macOSCompliancePolicy extends deviceCompliancePolicy {
  passwordRequired: boolean;
  passwordBlockSimple: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordPreviousPasswordBlockCount: number;
  passwordMinimumCharacterSetCount: number;
  passwordRequiredType: requiredPasswordType;
  osMinimumVersion: string;
  osMaximumVersion: string;
  systemIntegrityProtectionEnabled: boolean;
  deviceThreatProtectionEnabled: boolean;
  deviceThreatProtectionRequiredSecurityLevel: deviceThreatProtectionLevel;
  storageRequireEncryption: boolean;
  firewallEnabled: boolean;
  firewallBlockAllIncoming: boolean;
  firewallEnableStealthMode: boolean
}
