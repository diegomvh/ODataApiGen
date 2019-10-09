import { managedAppFlaggedReason } from './managedappflaggedreason.enum';
import { mobileAppIdentifier } from './mobileappidentifier.interface';
import { entity } from './entity.interface';
import { managedAppPolicy } from './managedapppolicy.interface';
import { managedAppOperation } from './managedappoperation.interface';

export interface managedAppRegistration extends entity {
  createdDateTime: Date;
  lastSyncDateTime: Date;
  applicationVersion: string;
  managementSdkVersion: string;
  platformVersion: string;
  deviceType: string;
  deviceTag: string;
  deviceName: string;
  flaggedReasons: managedAppFlaggedReason[];
  userId: string;
  appIdentifier: mobileAppIdentifier;
  version: string;
  appliedPolicies?: managedAppPolicy[];
  intendedPolicies?: managedAppPolicy[];
  operations?: managedAppOperation[]
}
