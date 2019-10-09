import { complianceStatus } from './compliancestatus.enum';
import { entity } from './entity.interface';

export interface deviceComplianceUserStatus extends entity {
  userDisplayName: string;
  devicesCount: number;
  status: complianceStatus;
  lastReportedDateTime: Date;
  userPrincipalName: string
}
