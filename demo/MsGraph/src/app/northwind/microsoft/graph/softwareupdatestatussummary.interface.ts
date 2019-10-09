import { entity } from './entity.interface';

export interface softwareUpdateStatusSummary extends entity {
  displayName: string;
  compliantDeviceCount: number;
  nonCompliantDeviceCount: number;
  remediatedDeviceCount: number;
  errorDeviceCount: number;
  unknownDeviceCount: number;
  conflictDeviceCount: number;
  notApplicableDeviceCount: number;
  compliantUserCount: number;
  nonCompliantUserCount: number;
  remediatedUserCount: number;
  errorUserCount: number;
  unknownUserCount: number;
  conflictUserCount: number;
  notApplicableUserCount: number
}
