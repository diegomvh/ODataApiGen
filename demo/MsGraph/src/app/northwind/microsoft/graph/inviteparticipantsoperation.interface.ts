import { invitationParticipantInfo } from './invitationparticipantinfo.interface';
import { commsOperation } from './commsoperation.interface';

export interface inviteParticipantsOperation extends commsOperation {
  participants: invitationParticipantInfo[]
}
