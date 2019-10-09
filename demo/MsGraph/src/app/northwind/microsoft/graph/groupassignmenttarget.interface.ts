import { deviceAndAppManagementAssignmentTarget } from './deviceandappmanagementassignmenttarget.interface';

export interface groupAssignmentTarget extends deviceAndAppManagementAssignmentTarget {
  groupId: string
}
