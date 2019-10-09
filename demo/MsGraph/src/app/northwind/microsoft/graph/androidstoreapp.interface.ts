import { androidMinimumOperatingSystem } from './androidminimumoperatingsystem.interface';
import { mobileApp } from './mobileapp.interface';

export interface androidStoreApp extends mobileApp {
  packageId: string;
  appStoreUrl: string;
  minimumSupportedOperatingSystem: androidMinimumOperatingSystem
}
