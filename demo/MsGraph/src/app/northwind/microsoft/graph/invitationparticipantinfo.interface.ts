import { participantInfo } from './participantinfo.interface';

export interface invitationParticipantInfo extends participantInfo {
  replacesCallId: string
}
