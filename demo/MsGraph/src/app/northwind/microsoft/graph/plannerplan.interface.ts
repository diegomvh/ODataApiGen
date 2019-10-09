import { identitySet } from './identityset.interface';
import { entity } from './entity.interface';
import { plannerTask } from './plannertask.interface';
import { plannerBucket } from './plannerbucket.interface';
import { plannerPlanDetails } from './plannerplandetails.interface';

export interface plannerPlan extends entity {
  createdBy: identitySet;
  createdDateTime: Date;
  owner: string;
  title: string;
  tasks?: plannerTask[];
  buckets?: plannerBucket[];
  details?: plannerPlanDetails
}
