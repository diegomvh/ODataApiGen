import { androidMinimumOperatingSystem } from './androidminimumoperatingsystem.interface';
import { mobileLobApp } from './mobilelobapp.interface';

export interface androidLobApp extends mobileLobApp {
  packageId: string;
  minimumSupportedOperatingSystem: androidMinimumOperatingSystem;
  versionName: string;
  versionCode: string
}
