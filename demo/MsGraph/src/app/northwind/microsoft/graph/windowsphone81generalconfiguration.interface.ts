import { appListType } from './applisttype.enum';
import { requiredPasswordType } from './requiredpasswordtype.enum';
import { appListItem } from './applistitem.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windowsPhone81GeneralConfiguration extends deviceConfiguration {
  applyOnlyToWindowsPhone81: boolean;
  appsBlockCopyPaste: boolean;
  bluetoothBlocked: boolean;
  cameraBlocked: boolean;
  cellularBlockWifiTethering: boolean;
  compliantAppsList: appListItem[];
  compliantAppListType: appListType;
  diagnosticDataBlockSubmission: boolean;
  emailBlockAddingAccounts: boolean;
  locationServicesBlocked: boolean;
  microsoftAccountBlocked: boolean;
  nfcBlocked: boolean;
  passwordBlockSimple: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeScreenTimeout: number;
  passwordMinimumCharacterSetCount: number;
  passwordPreviousPasswordBlockCount: number;
  passwordSignInFailureCountBeforeFactoryReset: number;
  passwordRequiredType: requiredPasswordType;
  passwordRequired: boolean;
  screenCaptureBlocked: boolean;
  storageBlockRemovableStorage: boolean;
  storageRequireEncryption: boolean;
  webBrowserBlocked: boolean;
  wifiBlocked: boolean;
  wifiBlockAutomaticConnectHotspots: boolean;
  wifiBlockHotspotReporting: boolean;
  windowsStoreBlocked: boolean
}
