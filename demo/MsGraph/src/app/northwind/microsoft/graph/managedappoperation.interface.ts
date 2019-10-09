import { entity } from './entity.interface';

export interface managedAppOperation extends entity {
  displayName: string;
  lastModifiedDateTime: Date;
  state: string;
  version: string
}
