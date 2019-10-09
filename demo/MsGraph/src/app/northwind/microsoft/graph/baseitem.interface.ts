import { identitySet } from './identityset.interface';
import { itemReference } from './itemreference.interface';
import { entity } from './entity.interface';
import { user } from './user.interface';

export interface baseItem extends entity {
  createdBy: identitySet;
  createdDateTime: Date;
  description: string;
  eTag: string;
  lastModifiedBy: identitySet;
  lastModifiedDateTime: Date;
  name: string;
  parentReference: itemReference;
  webUrl: string;
  createdByUser?: user;
  lastModifiedByUser?: user
}
