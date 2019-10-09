import { entity } from './entity.interface';
import { termsAndConditions } from './termsandconditions.interface';

export interface termsAndConditionsAcceptanceStatus extends entity {
  userDisplayName: string;
  acceptedVersion: number;
  acceptedDateTime: Date;
  termsAndConditions?: termsAndConditions
}
