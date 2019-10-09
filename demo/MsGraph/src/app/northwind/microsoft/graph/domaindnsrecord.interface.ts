import { entity } from './entity.interface';

export interface domainDnsRecord extends entity {
  isOptional: boolean;
  label: string;
  recordType: string;
  supportedService: string;
  ttl: number
}
