import { entity } from './entity.interface';
import { workbookChartLegendFormat } from './workbookchartlegendformat.interface';

export interface workbookChartLegend extends entity {
  overlay: boolean;
  position: string;
  visible: boolean;
  format?: workbookChartLegendFormat
}
