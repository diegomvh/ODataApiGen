import { appListItem } from './applistitem.interface';

export interface iosNetworkUsageRule {
  managedApps: appListItem[];
  cellularDataBlockWhenRoaming: boolean;
  cellularDataBlocked: boolean
}
