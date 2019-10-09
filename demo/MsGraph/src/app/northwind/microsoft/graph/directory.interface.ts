import { entity } from './entity.interface';
import { directoryObject } from './directoryobject.interface';

export interface directory extends entity {
  deletedItems?: directoryObject[]
}
