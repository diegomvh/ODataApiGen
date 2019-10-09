import { changeType } from './changetype.enum';

export interface commsNotification {
  changeType: changeType;
  resourceUrl: string
}
