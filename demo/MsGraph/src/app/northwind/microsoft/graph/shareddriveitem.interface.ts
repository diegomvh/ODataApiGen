import { identitySet } from './identityset.interface';
import { baseItem } from './baseitem.interface';
import { site } from './site.interface';
import { list } from './list.interface';
import { listItem } from './listitem.interface';
import { driveItem } from './driveitem.interface';

export interface sharedDriveItem extends baseItem {
  owner: identitySet;
  driveItem?: driveItem;
  items?: driveItem[];
  list?: list;
  listItem?: listItem;
  root?: driveItem;
  site?: site
}
