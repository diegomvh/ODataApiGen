import { managedAppDataEncryptionType } from './managedappdataencryptiontype.enum';
import { keyValuePair } from './keyvaluepair.interface';
import { managedAppProtection } from './managedappprotection.interface';
import { managedMobileApp } from './managedmobileapp.interface';
import { managedAppPolicyDeploymentSummary } from './managedapppolicydeploymentsummary.interface';

export interface defaultManagedAppProtection extends managedAppProtection {
  appDataEncryptionType: managedAppDataEncryptionType;
  screenCaptureBlocked: boolean;
  encryptAppData: boolean;
  disableAppEncryptionIfDeviceEncryptionIsEnabled: boolean;
  minimumRequiredSdkVersion: string;
  customSettings: keyValuePair[];
  deployedAppCount: number;
  minimumRequiredPatchVersion: string;
  minimumWarningPatchVersion: string;
  faceIdBlocked: boolean;
  apps?: managedMobileApp[];
  deploymentSummary?: managedAppPolicyDeploymentSummary
}
