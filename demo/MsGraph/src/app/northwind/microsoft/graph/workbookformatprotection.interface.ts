import { entity } from './entity.interface';

export interface workbookFormatProtection extends entity {
  formulaHidden: boolean;
  locked: boolean
}
