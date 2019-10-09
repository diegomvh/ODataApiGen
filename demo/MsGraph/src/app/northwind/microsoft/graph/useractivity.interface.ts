import { status } from './status.enum';
import { Json } from './json.interface';
import { visualInfo } from './visualinfo.interface';
import { entity } from './entity.interface';
import { activityHistoryItem } from './activityhistoryitem.interface';

export interface userActivity extends entity {
  visualElements: visualInfo;
  activitySourceHost: string;
  activationUrl: string;
  appActivityId: string;
  appDisplayName: string;
  contentUrl: string;
  createdDateTime: Date;
  expirationDateTime: Date;
  fallbackUrl: string;
  lastModifiedDateTime: Date;
  userTimezone: string;
  contentInfo: Json;
  status: status;
  historyItems?: activityHistoryItem[]
}
