

export const ISFLAGS_CALLSTATE = false;
export enum callState {
  incoming = 0,
  establishing = 1,
  established = 3,
  hold = 4,
  transferring = 5,
  transferAccepted = 6,
  redirecting = 7,
  terminating = 8,
  terminated = 9,
  unknownFutureValue = 10
}
