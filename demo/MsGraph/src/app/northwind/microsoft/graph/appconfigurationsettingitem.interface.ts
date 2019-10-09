import { mdmAppConfigKeyType } from './mdmappconfigkeytype.enum';

export interface appConfigurationSettingItem {
  appConfigKey: string;
  appConfigKeyType: mdmAppConfigKeyType;
  appConfigKeyValue: string
}
