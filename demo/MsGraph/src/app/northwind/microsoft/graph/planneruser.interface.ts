import { entity } from './entity.interface';
import { plannerTask } from './plannertask.interface';
import { plannerPlan } from './plannerplan.interface';

export interface plannerUser extends entity {
  tasks?: plannerTask[];
  plans?: plannerPlan[]
}
