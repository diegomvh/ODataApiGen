import { entity } from './entity.interface';
import { workbookWorksheet } from './workbookworksheet.interface';
import { workbookChartAxes } from './workbookchartaxes.interface';
import { workbookChartDataLabels } from './workbookchartdatalabels.interface';
import { workbookChartAreaFormat } from './workbookchartareaformat.interface';
import { workbookChartLegend } from './workbookchartlegend.interface';
import { workbookChartSeries } from './workbookchartseries.interface';
import { workbookChartTitle } from './workbookcharttitle.interface';

export interface workbookChart extends entity {
  height: number;
  left: number;
  name: string;
  top: number;
  width: number;
  axes?: workbookChartAxes;
  dataLabels?: workbookChartDataLabels;
  format?: workbookChartAreaFormat;
  legend?: workbookChartLegend;
  series?: workbookChartSeries[];
  title?: workbookChartTitle;
  worksheet?: workbookWorksheet
}
