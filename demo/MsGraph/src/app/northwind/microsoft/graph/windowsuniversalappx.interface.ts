import { windowsArchitecture } from './windowsarchitecture.enum';
import { windowsDeviceType } from './windowsdevicetype.enum';
import { windowsMinimumOperatingSystem } from './windowsminimumoperatingsystem.interface';
import { mobileLobApp } from './mobilelobapp.interface';

export interface windowsUniversalAppX extends mobileLobApp {
  applicableArchitectures: windowsArchitecture;
  applicableDeviceTypes: windowsDeviceType;
  identityName: string;
  identityPublisherHash: string;
  identityResourceIdentifier: string;
  isBundle: boolean;
  minimumSupportedOperatingSystem: windowsMinimumOperatingSystem;
  identityVersion: string
}
