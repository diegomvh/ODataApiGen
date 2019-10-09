import { deviceOperatingSystemSummary } from './deviceoperatingsystemsummary.interface';
import { deviceExchangeAccessStateSummary } from './deviceexchangeaccessstatesummary.interface';
import { entity } from './entity.interface';

export interface managedDeviceOverview extends entity {
  enrolledDeviceCount: number;
  mdmEnrolledCount: number;
  dualEnrolledDeviceCount: number;
  deviceOperatingSystemSummary: deviceOperatingSystemSummary;
  deviceExchangeAccessStateSummary: deviceExchangeAccessStateSummary
}
