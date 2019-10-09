import { windowsInformationProtectionApp } from './windowsinformationprotectionapp.interface';

export interface windowsInformationProtectionDesktopApp extends windowsInformationProtectionApp {
  binaryName: string;
  binaryVersionLow: string;
  binaryVersionHigh: string
}
