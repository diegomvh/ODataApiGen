import { installIntent } from './installintent.enum';
import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface managedEBookAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget;
  installIntent: installIntent
}
