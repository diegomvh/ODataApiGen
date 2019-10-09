

export const ISFLAGS_ALERTSTATUS = false;
export enum alertStatus {
  unknown = 0,
  newAlert = 1,
  inProgress = 2,
  resolved = 3,
  dismissed = 4,
  unknownFutureValue = 127
}
