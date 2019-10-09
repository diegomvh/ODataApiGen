import { entity } from './entity.interface';
import { termsAndConditionsAssignment } from './termsandconditionsassignment.interface';
import { termsAndConditionsAcceptanceStatus } from './termsandconditionsacceptancestatus.interface';

export interface termsAndConditions extends entity {
  createdDateTime: Date;
  lastModifiedDateTime: Date;
  displayName: string;
  description: string;
  title: string;
  bodyText: string;
  acceptanceStatement: string;
  version: number;
  assignments?: termsAndConditionsAssignment[];
  acceptanceStatuses?: termsAndConditionsAcceptanceStatus[]
}
