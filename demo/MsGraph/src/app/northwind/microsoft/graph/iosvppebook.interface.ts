import { managedEBook } from './managedebook.interface';

export interface iosVppEBook extends managedEBook {
  vppTokenId: string;
  appleId: string;
  vppOrganizationName: string;
  genres: string[];
  language: string;
  seller: string;
  totalLicenseCount: number;
  usedLicenseCount: number
}
