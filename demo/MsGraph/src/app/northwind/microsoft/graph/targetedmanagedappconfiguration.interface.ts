import { managedAppConfiguration } from './managedappconfiguration.interface';
import { managedMobileApp } from './managedmobileapp.interface';
import { targetedManagedAppPolicyAssignment } from './targetedmanagedapppolicyassignment.interface';
import { managedAppPolicyDeploymentSummary } from './managedapppolicydeploymentsummary.interface';

export interface targetedManagedAppConfiguration extends managedAppConfiguration {
  deployedAppCount: number;
  isAssigned: boolean;
  apps?: managedMobileApp[];
  deploymentSummary?: managedAppPolicyDeploymentSummary;
  assignments?: targetedManagedAppPolicyAssignment[]
}
