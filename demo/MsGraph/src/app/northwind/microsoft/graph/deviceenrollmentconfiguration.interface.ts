import { entity } from './entity.interface';
import { enrollmentConfigurationAssignment } from './enrollmentconfigurationassignment.interface';

export interface deviceEnrollmentConfiguration extends entity {
  displayName: string;
  description: string;
  priority: number;
  createdDateTime: Date;
  lastModifiedDateTime: Date;
  version: number;
  assignments?: enrollmentConfigurationAssignment[]
}
