import { entity } from './entity.interface';
import { workbookChartGridlinesFormat } from './workbookchartgridlinesformat.interface';

export interface workbookChartGridlines extends entity {
  visible: boolean;
  format?: workbookChartGridlinesFormat
}
