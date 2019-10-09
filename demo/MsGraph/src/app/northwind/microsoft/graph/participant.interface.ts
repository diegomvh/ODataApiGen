import { participantInfo } from './participantinfo.interface';
import { mediaStream } from './mediastream.interface';
import { entity } from './entity.interface';

export interface participant extends entity {
  info: participantInfo;
  mediaStreams: mediaStream[];
  isMuted: boolean;
  isInLobby: boolean
}
