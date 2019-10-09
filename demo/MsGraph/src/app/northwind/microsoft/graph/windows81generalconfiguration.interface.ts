import { requiredPasswordType } from './requiredpasswordtype.enum';
import { internetSiteSecurityLevel } from './internetsitesecuritylevel.enum';
import { siteSecurityLevel } from './sitesecuritylevel.enum';
import { windowsUserAccountControlSettings } from './windowsuseraccountcontrolsettings.enum';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows81GeneralConfiguration extends deviceConfiguration {
  accountsBlockAddingNonMicrosoftAccountEmail: boolean;
  applyOnlyToWindows81: boolean;
  browserBlockAutofill: boolean;
  browserBlockAutomaticDetectionOfIntranetSites: boolean;
  browserBlockEnterpriseModeAccess: boolean;
  browserBlockJavaScript: boolean;
  browserBlockPlugins: boolean;
  browserBlockPopups: boolean;
  browserBlockSendingDoNotTrackHeader: boolean;
  browserBlockSingleWordEntryOnIntranetSites: boolean;
  browserRequireSmartScreen: boolean;
  browserEnterpriseModeSiteListLocation: string;
  browserInternetSecurityLevel: internetSiteSecurityLevel;
  browserIntranetSecurityLevel: siteSecurityLevel;
  browserLoggingReportLocation: string;
  browserRequireHighSecurityForRestrictedSites: boolean;
  browserRequireFirewall: boolean;
  browserRequireFraudWarning: boolean;
  browserTrustedSitesSecurityLevel: siteSecurityLevel;
  cellularBlockDataRoaming: boolean;
  diagnosticsBlockDataSubmission: boolean;
  passwordBlockPicturePasswordAndPin: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeScreenTimeout: number;
  passwordMinimumCharacterSetCount: number;
  passwordPreviousPasswordBlockCount: number;
  passwordRequiredType: requiredPasswordType;
  passwordSignInFailureCountBeforeFactoryReset: number;
  storageRequireDeviceEncryption: boolean;
  updatesRequireAutomaticUpdates: boolean;
  userAccountControlSettings: windowsUserAccountControlSettings;
  workFoldersUrl: string
}
