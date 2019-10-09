import { entity } from './entity.interface';

export interface groupLifecyclePolicy extends entity {
  groupLifetimeInDays: number;
  managedGroupTypes: string;
  alternateNotificationEmails: string
}
