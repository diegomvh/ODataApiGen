import { root } from './root.interface';
import { sharepointIds } from './sharepointids.interface';
import { siteCollection } from './sitecollection.interface';
import { baseItem } from './baseitem.interface';
import { drive } from './drive.interface';
import { onenote } from './onenote.interface';
import { itemAnalytics } from './itemanalytics.interface';
import { columnDefinition } from './columndefinition.interface';
import { contentType } from './contenttype.interface';
import { list } from './list.interface';

export interface site extends baseItem {
  displayName: string;
  root: root;
  sharepointIds: sharepointIds;
  siteCollection: siteCollection;
  analytics?: itemAnalytics;
  columns?: columnDefinition[];
  contentTypes?: contentType[];
  drive?: drive;
  drives?: drive[];
  items?: baseItem[];
  lists?: list[];
  sites?: site[];
  onenote?: onenote
}
