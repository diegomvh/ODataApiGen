import { deviceActionResult } from './deviceactionresult.interface';

export interface deleteUserFromSharedAppleDeviceActionResult extends deviceActionResult {
  userPrincipalName: string
}
