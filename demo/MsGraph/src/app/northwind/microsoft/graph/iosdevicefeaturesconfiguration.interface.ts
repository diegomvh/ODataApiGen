import { iosHomeScreenItem } from './ioshomescreenitem.interface';
import { iosHomeScreenPage } from './ioshomescreenpage.interface';
import { iosNotificationSettings } from './iosnotificationsettings.interface';
import { appleDeviceFeaturesConfigurationBase } from './appledevicefeaturesconfigurationbase.interface';

export interface iosDeviceFeaturesConfiguration extends appleDeviceFeaturesConfigurationBase {
  assetTagTemplate: string;
  lockScreenFootnote: string;
  homeScreenDockIcons: iosHomeScreenItem[];
  homeScreenPages: iosHomeScreenPage[];
  notificationSettings: iosNotificationSettings[]
}
