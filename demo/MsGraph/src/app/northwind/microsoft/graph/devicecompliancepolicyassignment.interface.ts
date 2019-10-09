import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface deviceCompliancePolicyAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget
}
