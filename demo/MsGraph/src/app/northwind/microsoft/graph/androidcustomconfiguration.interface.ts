import { omaSetting } from './omasetting.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface androidCustomConfiguration extends deviceConfiguration {
  omaSettings: omaSetting[]
}
