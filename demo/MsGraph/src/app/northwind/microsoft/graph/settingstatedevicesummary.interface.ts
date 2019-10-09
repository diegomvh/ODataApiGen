import { entity } from './entity.interface';

export interface settingStateDeviceSummary extends entity {
  settingName: string;
  instancePath: string;
  unknownDeviceCount: number;
  notApplicableDeviceCount: number;
  compliantDeviceCount: number;
  remediatedDeviceCount: number;
  nonCompliantDeviceCount: number;
  errorDeviceCount: number;
  conflictDeviceCount: number
}
