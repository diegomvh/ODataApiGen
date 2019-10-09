import { entity } from './entity.interface';
import { message } from './message.interface';
import { singleValueLegacyExtendedProperty } from './singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './multivaluelegacyextendedproperty.interface';
import { messageRule } from './messagerule.interface';

export interface mailFolder extends entity {
  displayName: string;
  parentFolderId: string;
  childFolderCount: number;
  unreadItemCount: number;
  totalItemCount: number;
  singleValueExtendedProperties?: singleValueLegacyExtendedProperty[];
  multiValueExtendedProperties?: multiValueLegacyExtendedProperty[];
  messages?: message[];
  messageRules?: messageRule[];
  childFolders?: mailFolder[]
}
