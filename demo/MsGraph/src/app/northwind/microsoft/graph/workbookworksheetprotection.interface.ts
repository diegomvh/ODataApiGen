import { workbookWorksheetProtectionOptions } from './workbookworksheetprotectionoptions.interface';
import { entity } from './entity.interface';

export interface workbookWorksheetProtection extends entity {
  options: workbookWorksheetProtectionOptions;
  protected: boolean
}
