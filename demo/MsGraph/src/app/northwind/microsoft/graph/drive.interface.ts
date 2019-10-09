import { identitySet } from './identityset.interface';
import { sharepointIds } from './sharepointids.interface';
import { systemFacet } from './systemfacet.interface';
import { quota } from './quota.interface';
import { baseItem } from './baseitem.interface';
import { list } from './list.interface';
import { driveItem } from './driveitem.interface';

export interface drive extends baseItem {
  driveType: string;
  owner: identitySet;
  quota: quota;
  sharePointIds: sharepointIds;
  system: systemFacet;
  items?: driveItem[];
  list?: list;
  root?: driveItem;
  special?: driveItem[]
}
