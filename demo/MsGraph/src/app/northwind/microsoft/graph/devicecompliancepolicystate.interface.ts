import { complianceStatus } from './compliancestatus.enum';
import { policyPlatformType } from './policyplatformtype.enum';
import { deviceCompliancePolicySettingState } from './devicecompliancepolicysettingstate.interface';
import { entity } from './entity.interface';

export interface deviceCompliancePolicyState extends entity {
  settingStates: deviceCompliancePolicySettingState[];
  displayName: string;
  version: number;
  platformType: policyPlatformType;
  state: complianceStatus;
  settingCount: number
}
