import { installIntent } from './installintent.enum';
import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { mobileAppAssignmentSettings } from './mobileappassignmentsettings.interface';
import { entity } from './entity.interface';

export interface mobileAppAssignment extends entity {
  intent: installIntent;
  target: deviceAndAppManagementAssignmentTarget;
  settings: mobileAppAssignmentSettings
}
