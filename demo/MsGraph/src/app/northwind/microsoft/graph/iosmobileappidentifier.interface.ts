import { mobileAppIdentifier } from './mobileappidentifier.interface';

export interface iosMobileAppIdentifier extends mobileAppIdentifier {
  bundleId: string
}
