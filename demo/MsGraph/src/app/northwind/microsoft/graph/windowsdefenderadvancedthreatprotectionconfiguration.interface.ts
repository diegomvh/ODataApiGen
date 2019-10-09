import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windowsDefenderAdvancedThreatProtectionConfiguration extends deviceConfiguration {
  allowSampleSharing: boolean;
  enableExpeditedTelemetryReporting: boolean
}
