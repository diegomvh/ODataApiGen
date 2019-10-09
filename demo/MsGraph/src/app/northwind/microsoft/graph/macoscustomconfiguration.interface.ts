import { deviceConfiguration } from './deviceconfiguration.interface';

export interface macOSCustomConfiguration extends deviceConfiguration {
  payloadName: string;
  payloadFileName: string;
  payload: string
}
