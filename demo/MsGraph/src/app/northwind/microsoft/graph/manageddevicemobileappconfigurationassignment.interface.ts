import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';
import { entity } from './entity.interface';

export interface managedDeviceMobileAppConfigurationAssignment extends entity {
  target: deviceAndAppManagementAssignmentTarget
}
