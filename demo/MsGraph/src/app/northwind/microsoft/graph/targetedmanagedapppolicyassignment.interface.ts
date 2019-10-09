import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface targetedManagedAppPolicyAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget
}
