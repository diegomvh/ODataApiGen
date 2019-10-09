import { deviceComplianceActionType } from './devicecomplianceactiontype.enum';
import { entity } from './entity.interface';

export interface deviceComplianceActionItem extends entity {
  gracePeriodHours: number;
  actionType: deviceComplianceActionType;
  notificationTemplateId: string;
  notificationMessageCCList: string[]
}
