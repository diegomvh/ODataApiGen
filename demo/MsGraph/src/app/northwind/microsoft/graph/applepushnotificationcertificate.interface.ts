import { entity } from './entity.interface';

export interface applePushNotificationCertificate extends entity {
  appleIdentifier: string;
  topicIdentifier: string;
  lastModifiedDateTime: Date;
  expirationDateTime: Date;
  certificate: string
}
