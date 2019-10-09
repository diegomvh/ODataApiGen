import { entity } from './entity.interface';
import { workbookChartFill } from './workbookchartfill.interface';
import { workbookChartFont } from './workbookchartfont.interface';

export interface workbookChartLegendFormat extends entity {
  fill?: workbookChartFill;
  font?: workbookChartFont
}
