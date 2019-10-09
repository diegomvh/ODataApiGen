import { appConfigurationSettingItem } from './appconfigurationsettingitem.interface';
import { managedDeviceMobileAppConfiguration } from './manageddevicemobileappconfiguration.interface';

export interface iosMobileAppConfiguration extends managedDeviceMobileAppConfiguration {
  encodedSettingXml: string;
  settings: appConfigurationSettingItem[]
}
