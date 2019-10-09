import { Json } from './json.interface';
import { entity } from './entity.interface';
import { workbookChartAxisFormat } from './workbookchartaxisformat.interface';
import { workbookChartGridlines } from './workbookchartgridlines.interface';
import { workbookChartAxisTitle } from './workbookchartaxistitle.interface';

export interface workbookChartAxis extends entity {
  majorUnit: Json;
  maximum: Json;
  minimum: Json;
  minorUnit: Json;
  format?: workbookChartAxisFormat;
  majorGridlines?: workbookChartGridlines;
  minorGridlines?: workbookChartGridlines;
  title?: workbookChartAxisTitle
}
