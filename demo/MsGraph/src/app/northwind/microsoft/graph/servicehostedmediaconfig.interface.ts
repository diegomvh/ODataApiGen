import { mediaConfig } from './mediaconfig.interface';
import { mediaInfo } from './mediainfo.interface';

export interface serviceHostedMediaConfig extends mediaConfig {
  preFetchMedia: mediaInfo[]
}
