

export const ISFLAGS_LOGONTYPE = false;
export enum logonType {
  unknown = 0,
  interactive = 1,
  remoteInteractive = 2,
  network = 3,
  batch = 4,
  service = 5,
  unknownFutureValue = 127
}
