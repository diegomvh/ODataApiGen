import { entity } from './entity.interface';
import { workbookChartFont } from './workbookchartfont.interface';

export interface workbookChartAxisTitleFormat extends entity {
  font?: workbookChartFont
}
