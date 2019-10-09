import { deviceActionResult } from './deviceactionresult.interface';
import { deviceGeoLocation } from './devicegeolocation.interface';

export interface locateDeviceActionResult extends deviceActionResult {
  deviceLocation: deviceGeoLocation
}
