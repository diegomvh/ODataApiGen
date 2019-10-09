import { iosDeviceType } from './iosdevicetype.interface';
import { iosMinimumOperatingSystem } from './iosminimumoperatingsystem.interface';
import { managedMobileLobApp } from './managedmobilelobapp.interface';

export interface managedIOSLobApp extends managedMobileLobApp {
  bundleId: string;
  applicableDeviceType: iosDeviceType;
  minimumSupportedOperatingSystem: iosMinimumOperatingSystem;
  expirationDateTime: Date;
  versionNumber: string;
  buildNumber: string
}
