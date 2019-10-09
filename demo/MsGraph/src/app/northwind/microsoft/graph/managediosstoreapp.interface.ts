import { iosDeviceType } from './iosdevicetype.interface';
import { iosMinimumOperatingSystem } from './iosminimumoperatingsystem.interface';
import { managedApp } from './managedapp.interface';

export interface managedIOSStoreApp extends managedApp {
  bundleId: string;
  appStoreUrl: string;
  applicableDeviceType: iosDeviceType;
  minimumSupportedOperatingSystem: iosMinimumOperatingSystem
}
