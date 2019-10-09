import { entity } from './entity.interface';
import { plannerTask } from './plannertask.interface';

export interface plannerBucket extends entity {
  name: string;
  planId: string;
  orderHint: string;
  tasks?: plannerTask[]
}
