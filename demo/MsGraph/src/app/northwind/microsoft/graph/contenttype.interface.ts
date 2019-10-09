import { itemReference } from './itemreference.interface';
import { contentTypeOrder } from './contenttypeorder.interface';
import { entity } from './entity.interface';
import { columnLink } from './columnlink.interface';

export interface contentType extends entity {
  description: string;
  group: string;
  hidden: boolean;
  inheritedFrom: itemReference;
  name: string;
  order: contentTypeOrder;
  parentId: string;
  readOnly: boolean;
  sealed: boolean;
  columnLinks?: columnLink[]
}
