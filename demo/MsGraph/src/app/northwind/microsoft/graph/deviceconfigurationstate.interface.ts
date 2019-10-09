import { complianceStatus } from './compliancestatus.enum';
import { policyPlatformType } from './policyplatformtype.enum';
import { deviceConfigurationSettingState } from './deviceconfigurationsettingstate.interface';
import { entity } from './entity.interface';

export interface deviceConfigurationState extends entity {
  settingStates: deviceConfigurationSettingState[];
  displayName: string;
  version: number;
  platformType: policyPlatformType;
  state: complianceStatus;
  settingCount: number
}
