import { entity } from './entity.interface';

export interface deviceCompliancePolicyDeviceStateSummary extends entity {
  inGracePeriodCount: number;
  configManagerCount: number;
  unknownDeviceCount: number;
  notApplicableDeviceCount: number;
  compliantDeviceCount: number;
  remediatedDeviceCount: number;
  nonCompliantDeviceCount: number;
  errorDeviceCount: number;
  conflictDeviceCount: number
}
