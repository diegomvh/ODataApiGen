import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows10SecureAssessmentConfiguration extends deviceConfiguration {
  launchUri: string;
  configurationAccount: string;
  allowPrinting: boolean;
  allowScreenCapture: boolean;
  allowTextSuggestion: boolean
}
