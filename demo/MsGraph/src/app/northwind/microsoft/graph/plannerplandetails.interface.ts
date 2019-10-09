import { plannerUserIds } from './planneruserids.interface';
import { plannerCategoryDescriptions } from './plannercategorydescriptions.interface';
import { entity } from './entity.interface';

export interface plannerPlanDetails extends entity {
  sharedWith: plannerUserIds;
  categoryDescriptions: plannerCategoryDescriptions
}
