import { iosDeviceType } from './iosdevicetype.interface';
import { iosMinimumOperatingSystem } from './iosminimumoperatingsystem.interface';
import { mobileApp } from './mobileapp.interface';

export interface iosStoreApp extends mobileApp {
  bundleId: string;
  appStoreUrl: string;
  applicableDeviceType: iosDeviceType;
  minimumSupportedOperatingSystem: iosMinimumOperatingSystem
}
