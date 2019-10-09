import { timeZoneBase } from './timezonebase.interface';
import { standardTimeZoneOffset } from './standardtimezoneoffset.interface';
import { daylightTimeZoneOffset } from './daylighttimezoneoffset.interface';

export interface customTimeZone extends timeZoneBase {
  bias: number;
  standardOffset: standardTimeZoneOffset;
  daylightOffset: daylightTimeZoneOffset
}
