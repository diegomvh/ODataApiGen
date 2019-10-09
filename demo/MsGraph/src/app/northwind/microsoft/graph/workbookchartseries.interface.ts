import { entity } from './entity.interface';
import { workbookChartPoint } from './workbookchartpoint.interface';
import { workbookChartSeriesFormat } from './workbookchartseriesformat.interface';

export interface workbookChartSeries extends entity {
  name: string;
  format?: workbookChartSeriesFormat;
  points?: workbookChartPoint[]
}
