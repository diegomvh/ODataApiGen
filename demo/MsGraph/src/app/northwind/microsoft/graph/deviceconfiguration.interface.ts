import { entity } from './entity.interface';
import { deviceConfigurationAssignment } from './deviceconfigurationassignment.interface';
import { deviceConfigurationDeviceStatus } from './deviceconfigurationdevicestatus.interface';
import { deviceConfigurationUserStatus } from './deviceconfigurationuserstatus.interface';
import { deviceConfigurationDeviceOverview } from './deviceconfigurationdeviceoverview.interface';
import { deviceConfigurationUserOverview } from './deviceconfigurationuseroverview.interface';
import { settingStateDeviceSummary } from './settingstatedevicesummary.interface';

export interface deviceConfiguration extends entity {
  lastModifiedDateTime: Date;
  createdDateTime: Date;
  description: string;
  displayName: string;
  version: number;
  assignments?: deviceConfigurationAssignment[];
  deviceStatuses?: deviceConfigurationDeviceStatus[];
  userStatuses?: deviceConfigurationUserStatus[];
  deviceStatusOverview?: deviceConfigurationDeviceOverview;
  userStatusOverview?: deviceConfigurationUserOverview;
  deviceSettingStateSummaries?: settingStateDeviceSummary[]
}
