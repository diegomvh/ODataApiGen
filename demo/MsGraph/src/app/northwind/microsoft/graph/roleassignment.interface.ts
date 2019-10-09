import { entity } from './entity.interface';
import { roleDefinition } from './roledefinition.interface';

export interface roleAssignment extends entity {
  displayName: string;
  description: string;
  resourceScopes: string[];
  roleDefinition?: roleDefinition
}
