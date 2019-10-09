import { commsOperation } from './commsoperation.interface';

export interface recordOperation extends commsOperation {
  recordingLocation: string;
  recordingAccessToken: string
}
