import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface enrollmentConfigurationAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget
}
