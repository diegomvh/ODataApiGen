import { domainDnsRecord } from './domaindnsrecord.interface';

export interface domainDnsMxRecord extends domainDnsRecord {
  mailExchange: string;
  preference: number
}
