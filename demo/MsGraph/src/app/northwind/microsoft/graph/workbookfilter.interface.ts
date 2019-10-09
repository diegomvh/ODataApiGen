import { workbookFilterCriteria } from './workbookfiltercriteria.interface';
import { entity } from './entity.interface';

export interface workbookFilter extends entity {
  criteria: workbookFilterCriteria
}
