import { appListType } from './applisttype.enum';
import { requiredPasswordType } from './requiredpasswordtype.enum';
import { appListItem } from './applistitem.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface macOSGeneralDeviceConfiguration extends deviceConfiguration {
  compliantAppsList: appListItem[];
  compliantAppListType: appListType;
  emailInDomainSuffixes: string[];
  passwordBlockSimple: boolean;
  passwordExpirationDays: number;
  passwordMinimumCharacterSetCount: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeLock: number;
  passwordMinutesOfInactivityBeforeScreenTimeout: number;
  passwordPreviousPasswordBlockCount: number;
  passwordRequiredType: requiredPasswordType;
  passwordRequired: boolean
}
