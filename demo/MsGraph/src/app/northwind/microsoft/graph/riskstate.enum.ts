

export const ISFLAGS_RISKSTATE = false;
export enum riskState {
  none = 0,
  confirmedSafe = 1,
  remediated = 2,
  dismissed = 3,
  atRisk = 4,
  confirmedCompromised = 5,
  unknownFutureValue = 6
}
