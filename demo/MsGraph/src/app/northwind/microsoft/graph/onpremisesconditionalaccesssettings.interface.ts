import { entity } from './entity.interface';

export interface onPremisesConditionalAccessSettings extends entity {
  enabled: boolean;
  includedGroups: string[];
  excludedGroups: string[];
  overrideDefaultRule: boolean
}
