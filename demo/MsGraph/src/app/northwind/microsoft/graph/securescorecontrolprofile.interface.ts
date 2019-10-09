import { securityVendorInformation } from './securityvendorinformation.interface';
import { complianceInformation } from './complianceinformation.interface';
import { secureScoreControlStateUpdate } from './securescorecontrolstateupdate.interface';
import { entity } from './entity.interface';

export interface secureScoreControlProfile extends entity {
  actionType: string;
  actionUrl: string;
  azureTenantId: string;
  complianceInformation: complianceInformation[];
  controlCategory: string;
  controlStateUpdates: secureScoreControlStateUpdate[];
  deprecated: boolean;
  implementationCost: string;
  lastModifiedDateTime: Date;
  maxScore: number;
  rank: number;
  remediation: string;
  remediationImpact: string;
  service: string;
  threats: string[];
  tier: string;
  title: string;
  userImpact: string;
  vendorInformation: securityVendorInformation
}
