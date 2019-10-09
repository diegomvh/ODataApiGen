import { managedAppDataEncryptionType } from './managedappdataencryptiontype.enum';
import { targetedManagedAppProtection } from './targetedmanagedappprotection.interface';
import { managedMobileApp } from './managedmobileapp.interface';
import { managedAppPolicyDeploymentSummary } from './managedapppolicydeploymentsummary.interface';

export interface iosManagedAppProtection extends targetedManagedAppProtection {
  appDataEncryptionType: managedAppDataEncryptionType;
  minimumRequiredSdkVersion: string;
  deployedAppCount: number;
  faceIdBlocked: boolean;
  apps?: managedMobileApp[];
  deploymentSummary?: managedAppPolicyDeploymentSummary
}
