import { entity } from './entity.interface';
import { workbookChartFont } from './workbookchartfont.interface';
import { workbookChartLineFormat } from './workbookchartlineformat.interface';

export interface workbookChartAxisFormat extends entity {
  font?: workbookChartFont;
  line?: workbookChartLineFormat
}
