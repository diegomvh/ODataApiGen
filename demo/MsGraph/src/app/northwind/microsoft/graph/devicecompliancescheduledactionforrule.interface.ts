import { entity } from './entity.interface';
import { deviceComplianceActionItem } from './devicecomplianceactionitem.interface';

export interface deviceComplianceScheduledActionForRule extends entity {
  ruleName: string;
  scheduledActionConfigurations?: deviceComplianceActionItem[]
}
