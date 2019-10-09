import { meetingParticipantInfo } from './meetingparticipantinfo.interface';

export interface meetingParticipants {
  organizer: meetingParticipantInfo;
  attendees: meetingParticipantInfo[]
}
