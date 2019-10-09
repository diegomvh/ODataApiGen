import { identitySet } from './identityset.interface';
import { accessAction } from './accessaction.interface';
import { entity } from './entity.interface';
import { driveItem } from './driveitem.interface';

export interface itemActivity extends entity {
  access: accessAction;
  activityDateTime: Date;
  actor: identitySet;
  driveItem?: driveItem
}
