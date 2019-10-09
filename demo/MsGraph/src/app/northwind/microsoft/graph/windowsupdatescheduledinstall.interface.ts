import { weeklySchedule } from './weeklyschedule.enum';
import { windowsUpdateInstallScheduleType } from './windowsupdateinstallscheduletype.interface';

export interface windowsUpdateScheduledInstall extends windowsUpdateInstallScheduleType {
  scheduledInstallDay: weeklySchedule;
  scheduledInstallTime: any
}
