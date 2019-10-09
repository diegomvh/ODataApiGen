import { miracastChannel } from './miracastchannel.enum';
import { welcomeScreenMeetingInformation } from './welcomescreenmeetinginformation.enum';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows10TeamGeneralConfiguration extends deviceConfiguration {
  azureOperationalInsightsBlockTelemetry: boolean;
  azureOperationalInsightsWorkspaceId: string;
  azureOperationalInsightsWorkspaceKey: string;
  connectAppBlockAutoLaunch: boolean;
  maintenanceWindowBlocked: boolean;
  maintenanceWindowDurationInHours: number;
  maintenanceWindowStartTime: any;
  miracastChannel: miracastChannel;
  miracastBlocked: boolean;
  miracastRequirePin: boolean;
  settingsBlockMyMeetingsAndFiles: boolean;
  settingsBlockSessionResume: boolean;
  settingsBlockSigninSuggestions: boolean;
  settingsDefaultVolume: number;
  settingsScreenTimeoutInMinutes: number;
  settingsSessionTimeoutInMinutes: number;
  settingsSleepTimeoutInMinutes: number;
  welcomeScreenBlockAutomaticWakeUp: boolean;
  welcomeScreenBackgroundImageUrl: string;
  welcomeScreenMeetingInformation: welcomeScreenMeetingInformation
}
