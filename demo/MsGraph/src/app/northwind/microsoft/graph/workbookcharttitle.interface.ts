import { entity } from './entity.interface';
import { workbookChartTitleFormat } from './workbookcharttitleformat.interface';

export interface workbookChartTitle extends entity {
  overlay: boolean;
  text: string;
  visible: boolean;
  format?: workbookChartTitleFormat
}
