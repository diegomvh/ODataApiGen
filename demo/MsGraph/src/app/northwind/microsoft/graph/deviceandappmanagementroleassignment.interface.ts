import { roleAssignment } from './roleassignment.interface';

export interface deviceAndAppManagementRoleAssignment extends roleAssignment {
  members: string[]
}
