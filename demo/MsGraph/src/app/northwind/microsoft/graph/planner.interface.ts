import { entity } from './entity.interface';
import { plannerTask } from './plannertask.interface';
import { plannerPlan } from './plannerplan.interface';
import { plannerBucket } from './plannerbucket.interface';

export interface planner extends entity {
  tasks?: plannerTask[];
  plans?: plannerPlan[];
  buckets?: plannerBucket[]
}
