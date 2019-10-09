import { androidMinimumOperatingSystem } from './androidminimumoperatingsystem.interface';
import { managedApp } from './managedapp.interface';

export interface managedAndroidStoreApp extends managedApp {
  packageId: string;
  appStoreUrl: string;
  minimumSupportedOperatingSystem: androidMinimumOperatingSystem
}
