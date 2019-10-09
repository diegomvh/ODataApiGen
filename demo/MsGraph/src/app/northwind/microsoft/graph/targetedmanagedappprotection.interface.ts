import { managedAppProtection } from './managedappprotection.interface';
import { targetedManagedAppPolicyAssignment } from './targetedmanagedapppolicyassignment.interface';

export interface targetedManagedAppProtection extends managedAppProtection {
  isAssigned: boolean;
  assignments?: targetedManagedAppPolicyAssignment[]
}
