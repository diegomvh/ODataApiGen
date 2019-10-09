import { deviceActionResult } from './deviceactionresult.interface';

export interface resetPasscodeActionResult extends deviceActionResult {
  passcode: string
}
