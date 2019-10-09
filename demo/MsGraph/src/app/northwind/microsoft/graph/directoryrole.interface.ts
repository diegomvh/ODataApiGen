import { directoryObject } from './directoryobject.interface';

export interface directoryRole extends directoryObject {
  description: string;
  displayName: string;
  roleTemplateId: string;
  members?: directoryObject[]
}
