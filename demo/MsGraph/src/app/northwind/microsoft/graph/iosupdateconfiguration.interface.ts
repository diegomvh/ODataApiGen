import { dayOfWeek } from './dayofweek.enum';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface iosUpdateConfiguration extends deviceConfiguration {
  activeHoursStart: any;
  activeHoursEnd: any;
  scheduledInstallDays: dayOfWeek[];
  utcTimeOffsetInMinutes: number
}
