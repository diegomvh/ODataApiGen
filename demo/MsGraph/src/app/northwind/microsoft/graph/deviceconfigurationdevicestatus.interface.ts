import { complianceStatus } from './compliancestatus.enum';
import { entity } from './entity.interface';

export interface deviceConfigurationDeviceStatus extends entity {
  deviceDisplayName: string;
  userName: string;
  deviceModel: string;
  complianceGracePeriodExpirationDateTime: Date;
  status: complianceStatus;
  lastReportedDateTime: Date;
  userPrincipalName: string
}
