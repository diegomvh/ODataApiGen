import { windowsHelloForBusinessPinUsage } from './windowshelloforbusinesspinusage.enum';
import { enablement } from './enablement.enum';
import { deviceEnrollmentConfiguration } from './deviceenrollmentconfiguration.interface';

export interface deviceEnrollmentWindowsHelloForBusinessConfiguration extends deviceEnrollmentConfiguration {
  pinMinimumLength: number;
  pinMaximumLength: number;
  pinUppercaseCharactersUsage: windowsHelloForBusinessPinUsage;
  pinLowercaseCharactersUsage: windowsHelloForBusinessPinUsage;
  pinSpecialCharactersUsage: windowsHelloForBusinessPinUsage;
  state: enablement;
  securityDeviceRequired: boolean;
  unlockWithBiometricsEnabled: boolean;
  remotePassportEnabled: boolean;
  pinPreviousBlockCount: number;
  pinExpirationInDays: number;
  enhancedBiometricsState: enablement
}
