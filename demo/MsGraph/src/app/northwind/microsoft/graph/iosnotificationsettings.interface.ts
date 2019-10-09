import { iosNotificationAlertType } from './iosnotificationalerttype.enum';

export interface iosNotificationSettings {
  bundleID: string;
  appName: string;
  publisher: string;
  enabled: boolean;
  showInNotificationCenter: boolean;
  showOnLockScreen: boolean;
  alertType: iosNotificationAlertType;
  badgesEnabled: boolean;
  soundsEnabled: boolean
}
