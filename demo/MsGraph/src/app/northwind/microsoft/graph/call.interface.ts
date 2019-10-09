import { callDirection } from './calldirection.enum';
import { callState } from './callstate.enum';
import { modality } from './modality.enum';
import { callMediaState } from './callmediastate.interface';
import { resultInfo } from './resultinfo.interface';
import { participantInfo } from './participantinfo.interface';
import { mediaConfig } from './mediaconfig.interface';
import { chatInfo } from './chatinfo.interface';
import { meetingInfo } from './meetinginfo.interface';
import { toneInfo } from './toneinfo.interface';
import { entity } from './entity.interface';
import { participant } from './participant.interface';
import { commsOperation } from './commsoperation.interface';

export interface call extends entity {
  state: callState;
  mediaState: callMediaState;
  resultInfo: resultInfo;
  direction: callDirection;
  subject: string;
  callbackUri: string;
  source: participantInfo;
  targets: participantInfo[];
  requestedModalities: modality[];
  mediaConfig: mediaConfig;
  chatInfo: chatInfo;
  meetingInfo: meetingInfo;
  tenantId: string;
  myParticipantId: string;
  toneInfo: toneInfo;
  participants?: participant[];
  operations?: commsOperation[]
}
