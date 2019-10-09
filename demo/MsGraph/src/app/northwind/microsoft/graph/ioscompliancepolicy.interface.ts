import { requiredPasswordType } from './requiredpasswordtype.enum';
import { deviceThreatProtectionLevel } from './devicethreatprotectionlevel.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface iosCompliancePolicy extends deviceCompliancePolicy {
  passcodeBlockSimple: boolean;
  passcodeExpirationDays: number;
  passcodeMinimumLength: number;
  passcodeMinutesOfInactivityBeforeLock: number;
  passcodePreviousPasscodeBlockCount: number;
  passcodeMinimumCharacterSetCount: number;
  passcodeRequiredType: requiredPasswordType;
  passcodeRequired: boolean;
  osMinimumVersion: string;
  osMaximumVersion: string;
  securityBlockJailbrokenDevices: boolean;
  deviceThreatProtectionEnabled: boolean;
  deviceThreatProtectionRequiredSecurityLevel: deviceThreatProtectionLevel;
  managedEmailProfileRequired: boolean
}
