

export const ISFLAGS_IOSUPDATESINSTALLSTATUS = false;
export enum iosUpdatesInstallStatus {
  success = 0,
  available = 1,
  idle = 2,
  unknown = 3,
  downloading = -2016330712,
  downloadFailed = -2016330711,
  downloadRequiresComputer = -2016330710,
  downloadInsufficientSpace = -2016330709,
  downloadInsufficientPower = -2016330708,
  downloadInsufficientNetwork = -2016330707,
  installing = -2016330706,
  installInsufficientSpace = -2016330705,
  installInsufficientPower = -2016330704,
  installPhoneCallInProgress = -2016330703,
  installFailed = -2016330702,
  notSupportedOperation = -2016330701,
  sharedDeviceUserLoggedInError = -2016330699
}
