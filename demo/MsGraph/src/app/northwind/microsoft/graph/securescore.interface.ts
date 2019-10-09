import { securityVendorInformation } from './securityvendorinformation.interface';
import { averageComparativeScore } from './averagecomparativescore.interface';
import { controlScore } from './controlscore.interface';
import { entity } from './entity.interface';

export interface secureScore extends entity {
  activeUserCount: number;
  averageComparativeScores: averageComparativeScore[];
  azureTenantId: string;
  controlScores: controlScore[];
  createdDateTime: Date;
  currentScore: number;
  enabledServices: string[];
  licensedUserCount: number;
  maxScore: number;
  vendorInformation: securityVendorInformation
}
