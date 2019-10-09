import { domainDnsRecord } from './domaindnsrecord.interface';

export interface domainDnsCnameRecord extends domainDnsRecord {
  canonicalName: string
}
