import { baseItemVersion } from './baseitemversion.interface';

export interface driveItemVersion extends baseItemVersion {
  content: any;
  size: number
}
