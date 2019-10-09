import { mediaDirection } from './mediadirection.enum';
import { modality } from './modality.enum';

export interface mediaStream {
  mediaType: modality;
  label: string;
  sourceId: string;
  direction: mediaDirection;
  serverMuted: boolean
}
