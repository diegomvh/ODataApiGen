

export const ISFLAGS_INSTALLSTATE = false;
export enum installState {
  notApplicable = 0,
  installed = 1,
  failed = 2,
  notInstalled = 3,
  uninstallFailed = 4,
  unknown = 5
}
