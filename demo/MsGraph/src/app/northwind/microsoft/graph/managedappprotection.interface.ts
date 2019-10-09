import { managedAppDataStorageLocation } from './managedappdatastoragelocation.enum';
import { managedAppDataTransferLevel } from './managedappdatatransferlevel.enum';
import { managedAppClipboardSharingLevel } from './managedappclipboardsharinglevel.enum';
import { managedAppPinCharacterSet } from './managedapppincharacterset.enum';
import { managedAppPolicy } from './managedapppolicy.interface';

export interface managedAppProtection extends managedAppPolicy {
  periodOfflineBeforeAccessCheck: string;
  periodOnlineBeforeAccessCheck: string;
  allowedInboundDataTransferSources: managedAppDataTransferLevel;
  allowedOutboundDataTransferDestinations: managedAppDataTransferLevel;
  organizationalCredentialsRequired: boolean;
  allowedOutboundClipboardSharingLevel: managedAppClipboardSharingLevel;
  dataBackupBlocked: boolean;
  deviceComplianceRequired: boolean;
  managedBrowserToOpenLinksRequired: boolean;
  saveAsBlocked: boolean;
  periodOfflineBeforeWipeIsEnforced: string;
  pinRequired: boolean;
  maximumPinRetries: number;
  simplePinBlocked: boolean;
  minimumPinLength: number;
  pinCharacterSet: managedAppPinCharacterSet;
  periodBeforePinReset: string;
  allowedDataStorageLocations: managedAppDataStorageLocation[];
  contactSyncBlocked: boolean;
  printBlocked: boolean;
  fingerprintBlocked: boolean;
  disableAppPinIfDevicePinIsSet: boolean;
  minimumRequiredOsVersion: string;
  minimumWarningOsVersion: string;
  minimumRequiredAppVersion: string;
  minimumWarningAppVersion: string
}
