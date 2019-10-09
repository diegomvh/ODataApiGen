import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows10EnterpriseModernAppManagementConfiguration extends deviceConfiguration {
  uninstallBuiltInApps: boolean
}
