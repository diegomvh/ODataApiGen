import { chatInfo } from './chatinfo.interface';
import { meetingParticipants } from './meetingparticipants.interface';
import { audioConferencing } from './audioconferencing.interface';
import { entity } from './entity.interface';

export interface onlineMeeting extends entity {
  creationDateTime: Date;
  startDateTime: Date;
  endDateTime: Date;
  joinUrl: string;
  subject: string;
  participants: meetingParticipants;
  audioConferencing: audioConferencing;
  chatInfo: chatInfo;
  videoTeleconferenceId: string
}
