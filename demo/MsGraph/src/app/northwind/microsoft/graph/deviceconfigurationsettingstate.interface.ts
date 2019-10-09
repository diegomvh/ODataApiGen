import { complianceStatus } from './compliancestatus.enum';
import { settingSource } from './settingsource.interface';

export interface deviceConfigurationSettingState {
  setting: string;
  settingName: string;
  instanceDisplayName: string;
  state: complianceStatus;
  errorCode: number;
  errorDescription: string;
  userId: string;
  userName: string;
  userEmail: string;
  userPrincipalName: string;
  sources: settingSource[];
  currentValue: string
}
