import { mobileAppIdentifier } from './mobileappidentifier.interface';

export interface managedAppPolicyDeploymentSummaryPerApp {
  mobileAppIdentifier: mobileAppIdentifier;
  configurationAppliedUserCount: number
}
