import { messageRulePredicates } from './messagerulepredicates.interface';
import { messageRuleActions } from './messageruleactions.interface';
import { entity } from './entity.interface';

export interface messageRule extends entity {
  displayName: string;
  sequence: number;
  conditions: messageRulePredicates;
  actions: messageRuleActions;
  exceptions: messageRulePredicates;
  isEnabled: boolean;
  hasError: boolean;
  isReadOnly: boolean
}
