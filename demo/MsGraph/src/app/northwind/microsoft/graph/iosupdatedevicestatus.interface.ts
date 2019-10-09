import { complianceStatus } from './compliancestatus.enum';
import { iosUpdatesInstallStatus } from './iosupdatesinstallstatus.enum';
import { entity } from './entity.interface';

export interface iosUpdateDeviceStatus extends entity {
  installStatus: iosUpdatesInstallStatus;
  osVersion: string;
  deviceId: string;
  userId: string;
  deviceDisplayName: string;
  userName: string;
  deviceModel: string;
  complianceGracePeriodExpirationDateTime: Date;
  status: complianceStatus;
  lastReportedDateTime: Date;
  userPrincipalName: string
}
