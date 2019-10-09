import { managedAppPolicyDeploymentSummaryPerApp } from './managedapppolicydeploymentsummaryperapp.interface';
import { entity } from './entity.interface';

export interface managedAppPolicyDeploymentSummary extends entity {
  displayName: string;
  configurationDeployedUserCount: number;
  lastRefreshTime: Date;
  configurationDeploymentSummaryPerApp: managedAppPolicyDeploymentSummaryPerApp[];
  version: string
}
