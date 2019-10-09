import { entity } from './entity.interface';
import { mobileAppContentFile } from './mobileappcontentfile.interface';

export interface mobileAppContent extends entity {
  files?: mobileAppContentFile[]
}
