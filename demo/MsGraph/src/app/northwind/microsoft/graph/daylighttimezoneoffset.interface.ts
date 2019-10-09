import { standardTimeZoneOffset } from './standardtimezoneoffset.interface';

export interface daylightTimeZoneOffset extends standardTimeZoneOffset {
  daylightBias: number
}
