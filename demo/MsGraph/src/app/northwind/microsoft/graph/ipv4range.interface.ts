import { ipRange } from './iprange.interface';

export interface iPv4Range extends ipRange {
  lowerAddress: string;
  upperAddress: string
}
