import { plannerOrderHintsByAssignee } from './plannerorderhintsbyassignee.interface';
import { entity } from './entity.interface';

export interface plannerAssignedToTaskBoardTaskFormat extends entity {
  unassignedOrderHint: string;
  orderHintsByAssignee: plannerOrderHintsByAssignee
}
