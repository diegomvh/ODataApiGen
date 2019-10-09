import { mediaInfo } from './mediainfo.interface';
import { prompt } from './prompt.interface';

export interface mediaPrompt extends prompt {
  mediaInfo: mediaInfo
}
