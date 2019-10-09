import { userIdentity } from './useridentity.interface';
import { appIdentity } from './appidentity.interface';

export interface auditActivityInitiator {
  user: userIdentity;
  app: appIdentity
}
