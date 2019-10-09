import { windowsUpdateInstallScheduleType } from './windowsupdateinstallscheduletype.interface';

export interface windowsUpdateActiveHoursInstall extends windowsUpdateInstallScheduleType {
  activeHoursStart: any;
  activeHoursEnd: any
}
