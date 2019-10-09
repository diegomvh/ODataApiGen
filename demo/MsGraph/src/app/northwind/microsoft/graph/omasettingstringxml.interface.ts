import { omaSetting } from './omasetting.interface';

export interface omaSettingStringXml extends omaSetting {
  fileName: string;
  value: string
}
