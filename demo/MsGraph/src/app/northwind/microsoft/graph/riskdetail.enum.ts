

export const ISFLAGS_RISKDETAIL = false;
export enum riskDetail {
  none = 0,
  adminGeneratedTemporaryPassword = 1,
  userPerformedSecuredPasswordChange = 2,
  userPerformedSecuredPasswordReset = 3,
  adminConfirmedSigninSafe = 4,
  aiConfirmedSigninSafe = 5,
  userPassedMFADrivenByRiskBasedPolicy = 6,
  adminDismissedAllRiskForUser = 7,
  adminConfirmedSigninCompromised = 8,
  hidden = 9,
  adminConfirmedUserCompromised = 10,
  unknownFutureValue = 11
}
