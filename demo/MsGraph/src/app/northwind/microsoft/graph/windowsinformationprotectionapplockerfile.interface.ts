import { entity } from './entity.interface';

export interface windowsInformationProtectionAppLockerFile extends entity {
  displayName: string;
  fileHash: string;
  file: string;
  version: string
}
