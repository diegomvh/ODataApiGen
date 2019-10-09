import { notificationTemplateBrandingOptions } from './notificationtemplatebrandingoptions.enum';
import { entity } from './entity.interface';
import { localizedNotificationMessage } from './localizednotificationmessage.interface';

export interface notificationMessageTemplate extends entity {
  lastModifiedDateTime: Date;
  displayName: string;
  defaultLocale: string;
  brandingOptions: notificationTemplateBrandingOptions;
  localizedNotificationMessages?: localizedNotificationMessage[]
}
