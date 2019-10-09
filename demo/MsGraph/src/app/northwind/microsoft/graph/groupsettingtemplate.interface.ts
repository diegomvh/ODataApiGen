import { settingTemplateValue } from './settingtemplatevalue.interface';
import { directoryObject } from './directoryobject.interface';

export interface groupSettingTemplate extends directoryObject {
  displayName: string;
  description: string;
  values: settingTemplateValue[]
}
