import { entity } from './entity.interface';
import { plannerPlan } from './plannerplan.interface';

export interface plannerGroup extends entity {
  plans?: plannerPlan[]
}
