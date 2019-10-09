import { androidMinimumOperatingSystem } from './androidminimumoperatingsystem.interface';
import { managedMobileLobApp } from './managedmobilelobapp.interface';

export interface managedAndroidLobApp extends managedMobileLobApp {
  packageId: string;
  minimumSupportedOperatingSystem: androidMinimumOperatingSystem;
  versionName: string;
  versionCode: string
}
