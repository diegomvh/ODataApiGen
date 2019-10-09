import { entity } from './entity.interface';

export interface managedAppStatus extends entity {
  displayName: string;
  version: string
}
