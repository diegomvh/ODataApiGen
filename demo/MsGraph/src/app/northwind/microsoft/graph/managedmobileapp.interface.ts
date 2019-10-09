import { mobileAppIdentifier } from './mobileappidentifier.interface';
import { entity } from './entity.interface';

export interface managedMobileApp extends entity {
  mobileAppIdentifier: mobileAppIdentifier;
  version: string
}
