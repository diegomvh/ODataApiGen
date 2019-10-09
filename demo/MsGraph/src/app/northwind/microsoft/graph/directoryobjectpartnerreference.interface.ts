import { directoryObject } from './directoryobject.interface';

export interface directoryObjectPartnerReference extends directoryObject {
  description: string;
  displayName: string;
  externalPartnerTenantId: string;
  objectType: string
}
