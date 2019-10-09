import { sharepointIds } from './sharepointids.interface';
import { listInfo } from './listinfo.interface';
import { systemFacet } from './systemfacet.interface';
import { baseItem } from './baseitem.interface';
import { drive } from './drive.interface';
import { columnDefinition } from './columndefinition.interface';
import { contentType } from './contenttype.interface';
import { listItem } from './listitem.interface';

export interface list extends baseItem {
  displayName: string;
  list: listInfo;
  sharepointIds: sharepointIds;
  system: systemFacet;
  columns?: columnDefinition[];
  contentTypes?: contentType[];
  drive?: drive;
  items?: listItem[]
}
