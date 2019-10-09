import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface deviceConfigurationAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget
}
