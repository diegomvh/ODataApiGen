import { entity } from './entity.interface';

export interface eBookInstallSummary extends entity {
  installedDeviceCount: number;
  failedDeviceCount: number;
  notInstalledDeviceCount: number;
  installedUserCount: number;
  failedUserCount: number;
  notInstalledUserCount: number
}
