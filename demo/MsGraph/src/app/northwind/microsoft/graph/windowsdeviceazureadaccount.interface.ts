import { windowsDeviceAccount } from './windowsdeviceaccount.interface';

export interface windowsDeviceAzureADAccount extends windowsDeviceAccount {
  userPrincipalName: string
}
