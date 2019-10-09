import { entity } from './entity.interface';
import { workbookFormatProtection } from './workbookformatprotection.interface';
import { workbookRangeBorder } from './workbookrangeborder.interface';
import { workbookRangeFill } from './workbookrangefill.interface';
import { workbookRangeFont } from './workbookrangefont.interface';

export interface workbookRangeFormat extends entity {
  columnWidth: number;
  horizontalAlignment: string;
  rowHeight: number;
  verticalAlignment: string;
  wrapText: boolean;
  borders?: workbookRangeBorder[];
  fill?: workbookRangeFill;
  font?: workbookRangeFont;
  protection?: workbookFormatProtection
}
