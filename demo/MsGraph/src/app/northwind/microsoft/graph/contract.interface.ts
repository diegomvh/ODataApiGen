import { directoryObject } from './directoryobject.interface';

export interface contract extends directoryObject {
  contractType: string;
  customerId: string;
  defaultDomainName: string;
  displayName: string
}
