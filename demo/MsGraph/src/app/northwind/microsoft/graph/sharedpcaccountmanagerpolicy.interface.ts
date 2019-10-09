import { sharedPCAccountDeletionPolicyType } from './sharedpcaccountdeletionpolicytype.enum';

export interface sharedPCAccountManagerPolicy {
  accountDeletionPolicy: sharedPCAccountDeletionPolicyType;
  cacheAccountsAboveDiskFreePercentage: number;
  inactiveThresholdDays: number;
  removeAccountsBelowDiskFreePercentage: number
}
