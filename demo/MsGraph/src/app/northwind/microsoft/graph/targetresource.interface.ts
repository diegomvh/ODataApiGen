import { groupType } from './grouptype.enum';
import { modifiedProperty } from './modifiedproperty.interface';

export interface targetResource {
  id: string;
  displayName: string;
  type: string;
  userPrincipalName: string;
  groupType: groupType;
  modifiedProperties: modifiedProperty[]
}
