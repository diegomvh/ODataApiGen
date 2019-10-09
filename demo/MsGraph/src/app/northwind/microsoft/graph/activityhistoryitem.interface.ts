import { status } from './status.enum';
import { entity } from './entity.interface';
import { userActivity } from './useractivity.interface';

export interface activityHistoryItem extends entity {
  status: status;
  activeDurationSeconds: number;
  createdDateTime: Date;
  lastActiveDateTime: Date;
  lastModifiedDateTime: Date;
  expirationDateTime: Date;
  startedDateTime: Date;
  userTimezone: string;
  activity?: userActivity
}
