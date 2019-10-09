

export const ISFLAGS_AUTOMATICUPDATEMODE = false;
export enum automaticUpdateMode {
  userDefined = 0,
  notifyDownload = 1,
  autoInstallAtMaintenanceTime = 2,
  autoInstallAndRebootAtMaintenanceTime = 3,
  autoInstallAndRebootAtScheduledTime = 4,
  autoInstallAndRebootWithoutEndUserControl = 5
}
