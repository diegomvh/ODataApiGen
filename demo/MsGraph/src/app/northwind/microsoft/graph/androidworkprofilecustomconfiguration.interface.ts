import { omaSetting } from './omasetting.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface androidWorkProfileCustomConfiguration extends deviceConfiguration {
  omaSettings: omaSetting[]
}
