import { entity } from './entity.interface';
import { workbookChartFill } from './workbookchartfill.interface';
import { workbookChartFont } from './workbookchartfont.interface';

export interface workbookChartAreaFormat extends entity {
  fill?: workbookChartFill;
  font?: workbookChartFont
}
