import { entity } from './entity.interface';
import { workbookChartAxis } from './workbookchartaxis.interface';

export interface workbookChartAxes extends entity {
  categoryAxis?: workbookChartAxis;
  seriesAxis?: workbookChartAxis;
  valueAxis?: workbookChartAxis
}
