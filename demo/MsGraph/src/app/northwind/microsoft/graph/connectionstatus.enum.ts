

export const ISFLAGS_CONNECTIONSTATUS = false;
export enum connectionStatus {
  unknown = 0,
  attempted = 1,
  succeeded = 2,
  blocked = 3,
  failed = 4,
  unknownFutureValue = 127
}
