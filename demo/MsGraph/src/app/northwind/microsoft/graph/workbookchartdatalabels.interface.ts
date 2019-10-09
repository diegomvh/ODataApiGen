import { entity } from './entity.interface';
import { workbookChartDataLabelFormat } from './workbookchartdatalabelformat.interface';

export interface workbookChartDataLabels extends entity {
  position: string;
  separator: string;
  showBubbleSize: boolean;
  showCategoryName: boolean;
  showLegendKey: boolean;
  showPercentage: boolean;
  showSeriesName: boolean;
  showValue: boolean;
  format?: workbookChartDataLabelFormat
}
