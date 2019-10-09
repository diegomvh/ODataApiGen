import { domainDnsRecord } from './domaindnsrecord.interface';

export interface domainDnsSrvRecord extends domainDnsRecord {
  nameTarget: string;
  port: number;
  priority: number;
  protocol: string;
  service: string;
  weight: number
}
