import { deviceEnrollmentConfiguration } from './deviceenrollmentconfiguration.interface';

export interface deviceEnrollmentLimitConfiguration extends deviceEnrollmentConfiguration {
  limit: number
}
