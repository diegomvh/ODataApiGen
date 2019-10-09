import { windowsDeviceAccount } from './windowsdeviceaccount.interface';

export interface windowsDeviceADAccount extends windowsDeviceAccount {
  domainName: string;
  userName: string
}
