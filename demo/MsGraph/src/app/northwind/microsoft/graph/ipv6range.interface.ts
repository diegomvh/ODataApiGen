import { ipRange } from './iprange.interface';

export interface iPv6Range extends ipRange {
  lowerAddress: string;
  upperAddress: string
}
