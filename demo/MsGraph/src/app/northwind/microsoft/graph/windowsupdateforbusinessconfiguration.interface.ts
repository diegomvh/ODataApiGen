import { automaticUpdateMode } from './automaticupdatemode.enum';
import { prereleaseFeatures } from './prereleasefeatures.enum';
import { windowsDeliveryOptimizationMode } from './windowsdeliveryoptimizationmode.enum';
import { windowsUpdateType } from './windowsupdatetype.enum';
import { windowsUpdateInstallScheduleType } from './windowsupdateinstallscheduletype.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windowsUpdateForBusinessConfiguration extends deviceConfiguration {
  deliveryOptimizationMode: windowsDeliveryOptimizationMode;
  prereleaseFeatures: prereleaseFeatures;
  automaticUpdateMode: automaticUpdateMode;
  microsoftUpdateServiceAllowed: boolean;
  driversExcluded: boolean;
  installationSchedule: windowsUpdateInstallScheduleType;
  qualityUpdatesDeferralPeriodInDays: number;
  featureUpdatesDeferralPeriodInDays: number;
  qualityUpdatesPaused: boolean;
  featureUpdatesPaused: boolean;
  qualityUpdatesPauseExpiryDateTime: Date;
  featureUpdatesPauseExpiryDateTime: Date;
  businessReadyUpdatesOnly: windowsUpdateType
}
