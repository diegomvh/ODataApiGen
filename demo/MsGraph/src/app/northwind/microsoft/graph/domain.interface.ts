import { domainState } from './domainstate.interface';
import { entity } from './entity.interface';
import { directoryObject } from './directoryobject.interface';
import { domainDnsRecord } from './domaindnsrecord.interface';

export interface domain extends entity {
  authenticationType: string;
  availabilityStatus: string;
  isAdminManaged: boolean;
  isDefault: boolean;
  isInitial: boolean;
  isRoot: boolean;
  isVerified: boolean;
  passwordNotificationWindowInDays: number;
  passwordValidityPeriodInDays: number;
  supportedServices: string[];
  state: domainState;
  serviceConfigurationRecords?: domainDnsRecord[];
  verificationDnsRecords?: domainDnsRecord[];
  domainNameReferences?: directoryObject[]
}
