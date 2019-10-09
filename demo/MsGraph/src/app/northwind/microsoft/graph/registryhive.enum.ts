

export const ISFLAGS_REGISTRYHIVE = false;
export enum registryHive {
  unknown = 0,
  currentConfig = 1,
  currentUser = 2,
  localMachineSam = 3,
  localMachineSecurity = 4,
  localMachineSoftware = 5,
  localMachineSystem = 6,
  usersDefault = 7,
  unknownFutureValue = 127
}
