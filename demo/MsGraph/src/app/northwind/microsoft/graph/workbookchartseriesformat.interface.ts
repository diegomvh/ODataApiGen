import { entity } from './entity.interface';
import { workbookChartFill } from './workbookchartfill.interface';
import { workbookChartLineFormat } from './workbookchartlineformat.interface';

export interface workbookChartSeriesFormat extends entity {
  fill?: workbookChartFill;
  line?: workbookChartLineFormat
}
