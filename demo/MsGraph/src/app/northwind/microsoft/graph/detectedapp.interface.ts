import { entity } from './entity.interface';
import { managedDevice } from './manageddevice.interface';

export interface detectedApp extends entity {
  displayName: string;
  version: string;
  sizeInByte: number;
  deviceCount: number;
  managedDevices?: managedDevice[]
}
