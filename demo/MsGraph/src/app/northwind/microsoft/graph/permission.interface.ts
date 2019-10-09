import { identitySet } from './identityset.interface';
import { itemReference } from './itemreference.interface';
import { sharingInvitation } from './sharinginvitation.interface';
import { sharingLink } from './sharinglink.interface';
import { entity } from './entity.interface';

export interface permission extends entity {
  grantedTo: identitySet;
  inheritedFrom: itemReference;
  invitation: sharingInvitation;
  link: sharingLink;
  roles: string[];
  shareId: string
}
