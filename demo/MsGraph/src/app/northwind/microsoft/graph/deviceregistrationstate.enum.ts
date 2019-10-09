

export const ISFLAGS_DEVICEREGISTRATIONSTATE = false;
export enum deviceRegistrationState {
  notRegistered = 0,
  registered = 2,
  revoked = 3,
  keyConflict = 4,
  approvalPending = 5,
  certificateReset = 6,
  notRegisteredPendingEnrollment = 7,
  unknown = 8
}
