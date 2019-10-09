import { androidWorkProfileRequiredPasswordType } from './androidworkprofilerequiredpasswordtype.enum';
import { androidWorkProfileCrossProfileDataSharingType } from './androidworkprofilecrossprofiledatasharingtype.enum';
import { androidWorkProfileDefaultAppPermissionPolicyType } from './androidworkprofiledefaultapppermissionpolicytype.enum';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface androidWorkProfileGeneralDeviceConfiguration extends deviceConfiguration {
  passwordBlockFingerprintUnlock: boolean;
  passwordBlockTrustAgents: boolean;
  passwordExpirationDays: number;
  passwordMinimumLength: number;
  passwordMinutesOfInactivityBeforeScreenTimeout: number;
  passwordPreviousPasswordBlockCount: number;
  passwordSignInFailureCountBeforeFactoryReset: number;
  passwordRequiredType: androidWorkProfileRequiredPasswordType;
  workProfileDataSharingType: androidWorkProfileCrossProfileDataSharingType;
  workProfileBlockNotificationsWhileDeviceLocked: boolean;
  workProfileBlockAddingAccounts: boolean;
  workProfileBluetoothEnableContactSharing: boolean;
  workProfileBlockScreenCapture: boolean;
  workProfileBlockCrossProfileCallerId: boolean;
  workProfileBlockCamera: boolean;
  workProfileBlockCrossProfileContactsSearch: boolean;
  workProfileBlockCrossProfileCopyPaste: boolean;
  workProfileDefaultAppPermissionPolicy: androidWorkProfileDefaultAppPermissionPolicyType;
  workProfilePasswordBlockFingerprintUnlock: boolean;
  workProfilePasswordBlockTrustAgents: boolean;
  workProfilePasswordExpirationDays: number;
  workProfilePasswordMinimumLength: number;
  workProfilePasswordMinNumericCharacters: number;
  workProfilePasswordMinNonLetterCharacters: number;
  workProfilePasswordMinLetterCharacters: number;
  workProfilePasswordMinLowerCaseCharacters: number;
  workProfilePasswordMinUpperCaseCharacters: number;
  workProfilePasswordMinSymbolCharacters: number;
  workProfilePasswordMinutesOfInactivityBeforeScreenTimeout: number;
  workProfilePasswordPreviousPasswordBlockCount: number;
  workProfilePasswordSignInFailureCountBeforeFactoryReset: number;
  workProfilePasswordRequiredType: androidWorkProfileRequiredPasswordType;
  workProfileRequirePassword: boolean;
  securityRequireVerifyApps: boolean
}
