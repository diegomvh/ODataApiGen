import { settingValue } from './settingvalue.interface';
import { entity } from './entity.interface';

export interface groupSetting extends entity {
  displayName: string;
  templateId: string;
  values: settingValue[]
}
