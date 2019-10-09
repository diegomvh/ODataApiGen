

export const ISFLAGS_DEVICEENROLLMENTFAILUREREASON = false;
export enum deviceEnrollmentFailureReason {
  unknown = 0,
  authentication = 1,
  authorization = 2,
  accountValidation = 3,
  userValidation = 4,
  deviceNotSupported = 5,
  inMaintenance = 6,
  badRequest = 7,
  featureNotSupported = 8,
  enrollmentRestrictionsEnforced = 9,
  clientDisconnected = 10,
  userAbandonment = 11
}
