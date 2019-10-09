import { sharepointIds } from './sharepointids.interface';

export interface itemReference {
  driveId: string;
  driveType: string;
  id: string;
  name: string;
  path: string;
  shareId: string;
  sharepointIds: sharepointIds;
  siteId: string
}
