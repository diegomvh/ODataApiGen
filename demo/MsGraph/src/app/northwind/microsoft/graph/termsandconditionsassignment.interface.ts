import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface termsAndConditionsAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget
}
