import { entity } from './entity.interface';

export interface localizedNotificationMessage extends entity {
  lastModifiedDateTime: Date;
  locale: string;
  subject: string;
  messageTemplate: string;
  isDefault: boolean
}
