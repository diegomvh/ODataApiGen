import { entity } from './entity.interface';
import { workbookChartFill } from './workbookchartfill.interface';
import { workbookChartFont } from './workbookchartfont.interface';

export interface workbookChartTitleFormat extends entity {
  fill?: workbookChartFill;
  font?: workbookChartFont
}
