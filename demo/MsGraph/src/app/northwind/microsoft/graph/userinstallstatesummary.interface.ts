import { entity } from './entity.interface';
import { deviceInstallState } from './deviceinstallstate.interface';

export interface userInstallStateSummary extends entity {
  userName: string;
  installedDeviceCount: number;
  failedDeviceCount: number;
  notInstalledDeviceCount: number;
  deviceStates?: deviceInstallState[]
}
