import { entity } from './entity.interface';

export interface managedAppPolicy extends entity {
  displayName: string;
  description: string;
  createdDateTime: Date;
  lastModifiedDateTime: Date;
  version: string
}
