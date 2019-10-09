import { deviceEnrollmentPlatformRestriction } from './deviceenrollmentplatformrestriction.interface';
import { deviceEnrollmentConfiguration } from './deviceenrollmentconfiguration.interface';

export interface deviceEnrollmentPlatformRestrictionsConfiguration extends deviceEnrollmentConfiguration {
  iosRestriction: deviceEnrollmentPlatformRestriction;
  windowsRestriction: deviceEnrollmentPlatformRestriction;
  windowsMobileRestriction: deviceEnrollmentPlatformRestriction;
  androidRestriction: deviceEnrollmentPlatformRestriction;
  macOSRestriction: deviceEnrollmentPlatformRestriction
}
