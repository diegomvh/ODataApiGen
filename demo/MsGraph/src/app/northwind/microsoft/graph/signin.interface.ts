import { riskLevel } from './risklevel.enum';
import { conditionalAccessStatus } from './conditionalaccessstatus.enum';
import { riskState } from './riskstate.enum';
import { riskDetail } from './riskdetail.enum';
import { riskEventType } from './riskeventtype.enum';
import { signInStatus } from './signinstatus.interface';
import { deviceDetail } from './devicedetail.interface';
import { signInLocation } from './signinlocation.interface';
import { appliedConditionalAccessPolicy } from './appliedconditionalaccesspolicy.interface';
import { entity } from './entity.interface';

export interface signIn extends entity {
  createdDateTime: Date;
  userDisplayName: string;
  userPrincipalName: string;
  userId: string;
  appId: string;
  appDisplayName: string;
  ipAddress: string;
  status: signInStatus;
  clientAppUsed: string;
  deviceDetail: deviceDetail;
  location: signInLocation;
  correlationId: string;
  conditionalAccessStatus: conditionalAccessStatus;
  appliedConditionalAccessPolicies: appliedConditionalAccessPolicy[];
  isInteractive: boolean;
  riskDetail: riskDetail;
  riskLevelAggregated: riskLevel;
  riskLevelDuringSignIn: riskLevel;
  riskState: riskState;
  riskEventTypes: riskEventType[];
  resourceDisplayName: string;
  resourceId: string
}
