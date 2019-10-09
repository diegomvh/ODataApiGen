import { entity } from './entity.interface';
import { onlineMeeting } from './onlinemeeting.interface';
import { call } from './call.interface';

export interface cloudCommunications extends entity {
  calls?: call[];
  onlineMeetings?: onlineMeeting[]
}
