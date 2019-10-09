import { deviceConfiguration } from './deviceconfiguration.interface';

export interface iosCustomConfiguration extends deviceConfiguration {
  payloadName: string;
  payloadFileName: string;
  payload: string
}
