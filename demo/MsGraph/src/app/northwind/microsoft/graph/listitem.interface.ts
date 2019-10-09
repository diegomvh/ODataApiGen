import { sharepointIds } from './sharepointids.interface';
import { contentTypeInfo } from './contenttypeinfo.interface';
import { baseItem } from './baseitem.interface';
import { itemAnalytics } from './itemanalytics.interface';
import { driveItem } from './driveitem.interface';
import { fieldValueSet } from './fieldvalueset.interface';
import { listItemVersion } from './listitemversion.interface';

export interface listItem extends baseItem {
  contentType: contentTypeInfo;
  sharepointIds: sharepointIds;
  analytics?: itemAnalytics;
  driveItem?: driveItem;
  fields?: fieldValueSet;
  versions?: listItemVersion[]
}
