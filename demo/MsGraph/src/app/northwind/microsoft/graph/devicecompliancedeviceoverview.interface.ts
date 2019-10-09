import { entity } from './entity.interface';

export interface deviceComplianceDeviceOverview extends entity {
  pendingCount: number;
  notApplicableCount: number;
  successCount: number;
  errorCount: number;
  failedCount: number;
  lastUpdateDateTime: Date;
  configurationVersion: number
}
