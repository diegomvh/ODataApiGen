import { entity } from './entity.interface';

export interface telecomExpenseManagementPartner extends entity {
  displayName: string;
  url: string;
  appAuthorized: boolean;
  enabled: boolean;
  lastConnectionDateTime: Date
}
