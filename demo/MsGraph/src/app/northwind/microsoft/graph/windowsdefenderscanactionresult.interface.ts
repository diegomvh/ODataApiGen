import { deviceActionResult } from './deviceactionresult.interface';

export interface windowsDefenderScanActionResult extends deviceActionResult {
  scanType: string
}
