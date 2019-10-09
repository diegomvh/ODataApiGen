import { mobileAppAssignmentSettings } from './mobileappassignmentsettings.interface';

export interface iosVppAppAssignmentSettings extends mobileAppAssignmentSettings {
  useDeviceLicensing: boolean;
  vpnConfigurationId: string
}
