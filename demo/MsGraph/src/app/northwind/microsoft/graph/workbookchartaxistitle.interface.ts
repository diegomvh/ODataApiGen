import { entity } from './entity.interface';
import { workbookChartAxisTitleFormat } from './workbookchartaxistitleformat.interface';

export interface workbookChartAxisTitle extends entity {
  text: string;
  visible: boolean;
  format?: workbookChartAxisTitleFormat
}
