import { windowsDeviceAccount } from './windowsdeviceaccount.interface';

export interface updateWindowsDeviceAccountActionParameter {
  deviceAccount: windowsDeviceAccount;
  passwordRotationEnabled: boolean;
  calendarSyncEnabled: boolean;
  deviceAccountEmail: string;
  exchangeServer: string;
  sessionInitiationProtocalAddress: string
}
