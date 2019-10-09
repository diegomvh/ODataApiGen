import { entity } from './entity.interface';
import { workbookChartFill } from './workbookchartfill.interface';

export interface workbookChartPointFormat extends entity {
  fill?: workbookChartFill
}
