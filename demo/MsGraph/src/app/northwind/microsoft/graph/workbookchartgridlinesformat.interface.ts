import { entity } from './entity.interface';
import { workbookChartLineFormat } from './workbookchartlineformat.interface';

export interface workbookChartGridlinesFormat extends entity {
  line?: workbookChartLineFormat
}
