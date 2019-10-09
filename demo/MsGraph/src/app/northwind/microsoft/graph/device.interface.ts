import { alternativeSecurityId } from './alternativesecurityid.interface';
import { directoryObject } from './directoryobject.interface';
import { extension } from './extension.interface';

export interface device extends directoryObject {
  accountEnabled: boolean;
  alternativeSecurityIds: alternativeSecurityId[];
  approximateLastSignInDateTime: Date;
  complianceExpirationDateTime: Date;
  deviceId: string;
  deviceMetadata: string;
  deviceVersion: number;
  displayName: string;
  isCompliant: boolean;
  isManaged: boolean;
  onPremisesLastSyncDateTime: Date;
  onPremisesSyncEnabled: boolean;
  operatingSystem: string;
  operatingSystemVersion: string;
  physicalIds: string[];
  profileType: string;
  systemLabels: string[];
  trustType: string;
  memberOf?: directoryObject[];
  registeredOwners?: directoryObject[];
  registeredUsers?: directoryObject[];
  transitiveMemberOf?: directoryObject[];
  extensions?: extension[]
}
