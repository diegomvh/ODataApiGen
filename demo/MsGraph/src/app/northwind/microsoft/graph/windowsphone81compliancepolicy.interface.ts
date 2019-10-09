import { requiredPasswordType } from './requiredpasswordtype.enum';
import { deviceCompliancePolicy } from './devicecompliancepolicy.interface';

export interface windowsPhone81CompliancePolicy extends deviceCompliancePolicy {
  passwordBlockSimple: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordMinimumCharacterSetCount: number;
  passwordRequiredType: requiredPasswordType;
  passwordPreviousPasswordBlockCount: number;
  passwordRequired: boolean;
  osMinimumVersion: string;
  osMaximumVersion: string;
  storageRequireEncryption: boolean
}
