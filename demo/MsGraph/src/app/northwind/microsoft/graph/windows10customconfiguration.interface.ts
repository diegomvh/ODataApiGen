import { omaSetting } from './omasetting.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows10CustomConfiguration extends deviceConfiguration {
  omaSettings: omaSetting[]
}
