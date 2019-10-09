import { omaSetting } from './omasetting.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windowsPhone81CustomConfiguration extends deviceConfiguration {
  omaSettings: omaSetting[]
}
