import { microsoftStoreForBusinessLicenseType } from './microsoftstoreforbusinesslicensetype.enum';
import { mobileApp } from './mobileapp.interface';

export interface microsoftStoreForBusinessApp extends mobileApp {
  usedLicenseCount: number;
  totalLicenseCount: number;
  productKey: string;
  licenseType: microsoftStoreForBusinessLicenseType;
  packageIdentityName: string
}
