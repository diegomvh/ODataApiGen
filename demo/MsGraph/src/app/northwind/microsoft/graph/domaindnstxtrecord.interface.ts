import { domainDnsRecord } from './domaindnsrecord.interface';

export interface domainDnsTxtRecord extends domainDnsRecord {
  text: string
}
