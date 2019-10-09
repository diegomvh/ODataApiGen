import { deviceEnrollmentType } from './deviceenrollmenttype.enum';
import { deviceEnrollmentFailureReason } from './deviceenrollmentfailurereason.enum';
import { deviceManagementTroubleshootingEvent } from './devicemanagementtroubleshootingevent.interface';

export interface enrollmentTroubleshootingEvent extends deviceManagementTroubleshootingEvent {
  managedDeviceIdentifier: string;
  operatingSystem: string;
  osVersion: string;
  userId: string;
  deviceId: string;
  enrollmentType: deviceEnrollmentType;
  failureCategory: deviceEnrollmentFailureReason;
  failureReason: string
}
