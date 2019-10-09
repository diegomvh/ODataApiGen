import { requiredPasswordType } from './requiredpasswordtype.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface windows81CompliancePolicy extends deviceCompliancePolicy {
  passwordRequired: boolean;
  passwordBlockSimple: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordMinimumCharacterSetCount: number;
  passwordRequiredType: requiredPasswordType;
  passwordPreviousPasswordBlockCount: number;
  osMinimumVersion: string;
  osMaximumVersion: string;
  storageRequireEncryption: boolean
}
