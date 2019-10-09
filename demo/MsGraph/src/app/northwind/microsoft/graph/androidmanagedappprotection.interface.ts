import { targetedManagedAppProtection } from './targetedmanagedappprotection.interface';
import { managedMobileApp } from './managedmobileapp.interface';
import { managedAppPolicyDeploymentSummary } from './managedapppolicydeploymentsummary.interface';

export interface androidManagedAppProtection extends targetedManagedAppProtection {
  screenCaptureBlocked: boolean;
  disableAppEncryptionIfDeviceEncryptionIsEnabled: boolean;
  encryptAppData: boolean;
  deployedAppCount: number;
  minimumRequiredPatchVersion: string;
  minimumWarningPatchVersion: string;
  apps?: managedMobileApp[];
  deploymentSummary?: managedAppPolicyDeploymentSummary
}
