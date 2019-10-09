import { domainDnsRecord } from './domaindnsrecord.interface';

export interface domainDnsUnavailableRecord extends domainDnsRecord {
  description: string
}
