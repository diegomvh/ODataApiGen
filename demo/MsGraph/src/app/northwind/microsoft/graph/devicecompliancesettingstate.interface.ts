import { complianceStatus } from './compliancestatus.enum';
import { entity } from './entity.interface';

export interface deviceComplianceSettingState extends entity {
  setting: string;
  settingName: string;
  deviceId: string;
  deviceName: string;
  userId: string;
  userEmail: string;
  userName: string;
  userPrincipalName: string;
  deviceModel: string;
  state: complianceStatus;
  complianceGracePeriodExpirationDateTime: Date
}
