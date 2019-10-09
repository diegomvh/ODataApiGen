import { appliedConditionalAccessPolicyResult } from './appliedconditionalaccesspolicyresult.enum';

export interface appliedConditionalAccessPolicy {
  id: string;
  displayName: string;
  enforcedGrantControls: string[];
  enforcedSessionControls: string[];
  result: appliedConditionalAccessPolicyResult
}
