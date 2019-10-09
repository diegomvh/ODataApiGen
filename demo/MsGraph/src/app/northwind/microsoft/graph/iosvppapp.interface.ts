import { vppTokenAccountType } from './vpptokenaccounttype.enum';
import { iosDeviceType } from './iosdevicetype.interface';
import { vppLicensingType } from './vpplicensingtype.interface';
import { mobileApp } from './mobileapp.interface';

export interface iosVppApp extends mobileApp {
  usedLicenseCount: number;
  totalLicenseCount: number;
  releaseDateTime: Date;
  appStoreUrl: string;
  licensingType: vppLicensingType;
  applicableDeviceType: iosDeviceType;
  vppTokenOrganizationName: string;
  vppTokenAccountType: vppTokenAccountType;
  vppTokenAppleId: string;
  bundleId: string
}
