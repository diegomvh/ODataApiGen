import { mobileAppIdentifier } from './mobileappidentifier.interface';

export interface androidMobileAppIdentifier extends mobileAppIdentifier {
  packageId: string
}
