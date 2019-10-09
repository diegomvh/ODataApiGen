import { policyPlatformType } from './policyplatformtype.enum';
import { entity } from './entity.interface';
import { deviceComplianceSettingState } from './devicecompliancesettingstate.interface';

export interface deviceCompliancePolicySettingStateSummary extends entity {
  setting: string;
  settingName: string;
  platformType: policyPlatformType;
  unknownDeviceCount: number;
  notApplicableDeviceCount: number;
  compliantDeviceCount: number;
  remediatedDeviceCount: number;
  nonCompliantDeviceCount: number;
  errorDeviceCount: number;
  conflictDeviceCount: number;
  deviceComplianceSettingStates?: deviceComplianceSettingState[]
}
