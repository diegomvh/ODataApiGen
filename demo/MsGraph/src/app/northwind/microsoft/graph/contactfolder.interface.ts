import { entity } from './entity.interface';
import { contact } from './contact.interface';
import { singleValueLegacyExtendedProperty } from './singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './multivaluelegacyextendedproperty.interface';

export interface contactFolder extends entity {
  parentFolderId: string;
  displayName: string;
  singleValueExtendedProperties?: singleValueLegacyExtendedProperty[];
  multiValueExtendedProperties?: multiValueLegacyExtendedProperty[];
  contacts?: contact[];
  childFolders?: contactFolder[]
}
