

export const ISFLAGS_DEVICEENROLLMENTTYPE = false;
export enum deviceEnrollmentType {
  unknown = 0,
  userEnrollment = 1,
  deviceEnrollmentManager = 2,
  appleBulkWithUser = 3,
  appleBulkWithoutUser = 4,
  windowsAzureADJoin = 5,
  windowsBulkUserless = 6,
  windowsAutoEnrollment = 7,
  windowsBulkAzureDomainJoin = 8,
  windowsCoManagement = 9
}
