import { omaSetting } from './omasetting.interface';

export interface omaSettingBase64 extends omaSetting {
  fileName: string;
  value: string
}
