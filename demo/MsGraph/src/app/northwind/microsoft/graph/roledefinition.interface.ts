import { rolePermission } from './rolepermission.interface';
import { entity } from './entity.interface';
import { roleAssignment } from './roleassignment.interface';

export interface roleDefinition extends entity {
  displayName: string;
  description: string;
  rolePermissions: rolePermission[];
  isBuiltIn: boolean;
  roleAssignments?: roleAssignment[]
}
