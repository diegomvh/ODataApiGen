import { entity } from './entity.interface';
import { settingStateDeviceSummary } from './settingstatedevicesummary.interface';
import { deviceCompliancePolicyAssignment } from './devicecompliancepolicyassignment.interface';
import { deviceComplianceScheduledActionForRule } from './devicecompliancescheduledactionforrule.interface';
import { deviceComplianceDeviceStatus } from './devicecompliancedevicestatus.interface';
import { deviceComplianceUserStatus } from './devicecomplianceuserstatus.interface';
import { deviceComplianceDeviceOverview } from './devicecompliancedeviceoverview.interface';
import { deviceComplianceUserOverview } from './devicecomplianceuseroverview.interface';

export interface deviceCompliancePolicy extends entity {
  createdDateTime: Date;
  description: string;
  lastModifiedDateTime: Date;
  displayName: string;
  version: number;
  scheduledActionsForRule?: deviceComplianceScheduledActionForRule[];
  deviceStatuses?: deviceComplianceDeviceStatus[];
  userStatuses?: deviceComplianceUserStatus[];
  deviceStatusOverview?: deviceComplianceDeviceOverview;
  userStatusOverview?: deviceComplianceUserOverview;
  deviceSettingStateSummaries?: settingStateDeviceSummary[];
  assignments?: deviceCompliancePolicyAssignment[]
}
