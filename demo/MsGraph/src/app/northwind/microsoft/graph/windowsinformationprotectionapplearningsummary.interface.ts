import { applicationType } from './applicationtype.enum';
import { entity } from './entity.interface';

export interface windowsInformationProtectionAppLearningSummary extends entity {
  applicationName: string;
  applicationType: applicationType;
  deviceCount: number
}
