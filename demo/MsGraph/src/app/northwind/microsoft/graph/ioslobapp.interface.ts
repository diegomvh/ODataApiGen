import { iosDeviceType } from './iosdevicetype.interface';
import { iosMinimumOperatingSystem } from './iosminimumoperatingsystem.interface';
import { mobileLobApp } from './mobilelobapp.interface';

export interface iosLobApp extends mobileLobApp {
  bundleId: string;
  applicableDeviceType: iosDeviceType;
  minimumSupportedOperatingSystem: iosMinimumOperatingSystem;
  expirationDateTime: Date;
  versionNumber: string;
  buildNumber: string
}
