import { sharedPCAllowedAccountType } from './sharedpcallowedaccounttype.enum';
import { sharedPCAccountManagerPolicy } from './sharedpcaccountmanagerpolicy.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface sharedPCConfiguration extends deviceConfiguration {
  accountManagerPolicy: sharedPCAccountManagerPolicy;
  allowedAccounts: sharedPCAllowedAccountType;
  allowLocalStorage: boolean;
  disableAccountManager: boolean;
  disableEduPolicies: boolean;
  disablePowerPolicies: boolean;
  disableSignInOnResume: boolean;
  enabled: boolean;
  idleTimeBeforeSleepInSeconds: number;
  kioskAppDisplayName: string;
  kioskAppUserModelId: string;
  maintenanceStartTime: any
}
