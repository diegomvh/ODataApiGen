import { deviceActionResult } from './deviceactionresult.interface';

export interface remoteLockActionResult extends deviceActionResult {
  unlockPin: string
}
