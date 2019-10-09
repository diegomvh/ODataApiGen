import { entity } from './entity.interface';

export interface subscription extends entity {
  resource: string;
  changeType: string;
  clientState: string;
  notificationUrl: string;
  expirationDateTime: Date;
  applicationId: string;
  creatorId: string
}
