import { Json } from './json.interface';
import { entity } from './entity.interface';
import { workbookChartPointFormat } from './workbookchartpointformat.interface';

export interface workbookChartPoint extends entity {
  value: Json;
  format?: workbookChartPointFormat
}
