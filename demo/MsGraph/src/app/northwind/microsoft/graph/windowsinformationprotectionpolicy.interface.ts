import { windowsInformationProtectionPinCharacterRequirements } from './windowsinformationprotectionpincharacterrequirements.enum';
import { windowsInformationProtection } from './windowsinformationprotection.interface';

export interface windowsInformationProtectionPolicy extends windowsInformationProtection {
  revokeOnMdmHandoffDisabled: boolean;
  mdmEnrollmentUrl: string;
  windowsHelloForBusinessBlocked: boolean;
  pinMinimumLength: number;
  pinUppercaseLetters: windowsInformationProtectionPinCharacterRequirements;
  pinLowercaseLetters: windowsInformationProtectionPinCharacterRequirements;
  pinSpecialCharacters: windowsInformationProtectionPinCharacterRequirements;
  pinExpirationDays: number;
  numberOfPastPinsRemembered: number;
  passwordMaximumAttemptCount: number;
  minutesOfInactivityBeforeDeviceLock: number;
  daysWithoutContactBeforeUnenroll: number
}
