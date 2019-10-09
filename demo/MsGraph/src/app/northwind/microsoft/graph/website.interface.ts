import { websiteType } from './websitetype.enum';

export interface website {
  type: websiteType;
  address: string;
  displayName: string
}
