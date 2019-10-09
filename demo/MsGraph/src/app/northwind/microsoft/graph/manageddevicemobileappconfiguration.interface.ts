import { entity } from './entity.interface';
import { managedDeviceMobileAppConfigurationAssignment } from './manageddevicemobileappconfigurationassignment.interface';
import { managedDeviceMobileAppConfigurationDeviceStatus } from './manageddevicemobileappconfigurationdevicestatus.interface';
import { managedDeviceMobileAppConfigurationUserStatus } from './manageddevicemobileappconfigurationuserstatus.interface';
import { managedDeviceMobileAppConfigurationDeviceSummary } from './manageddevicemobileappconfigurationdevicesummary.interface';
import { managedDeviceMobileAppConfigurationUserSummary } from './manageddevicemobileappconfigurationusersummary.interface';

export interface managedDeviceMobileAppConfiguration extends entity {
  targetedMobileApps: string[];
  createdDateTime: Date;
  description: string;
  lastModifiedDateTime: Date;
  displayName: string;
  version: number;
  assignments?: managedDeviceMobileAppConfigurationAssignment[];
  deviceStatuses?: managedDeviceMobileAppConfigurationDeviceStatus[];
  userStatuses?: managedDeviceMobileAppConfigurationUserStatus[];
  deviceStatusSummary?: managedDeviceMobileAppConfigurationDeviceSummary;
  userStatusSummary?: managedDeviceMobileAppConfigurationUserSummary
}
