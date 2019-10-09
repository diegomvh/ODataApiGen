import { installState } from './installstate.enum';
import { entity } from './entity.interface';

export interface deviceInstallState extends entity {
  deviceName: string;
  deviceId: string;
  lastSyncDateTime: Date;
  installState: installState;
  errorCode: string;
  osVersion: string;
  osDescription: string;
  userName: string
}
