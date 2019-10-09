import { alertFeedback } from './alertfeedback.enum';
import { alertStatus } from './alertstatus.enum';

export interface alertHistoryState {
  appId: string;
  assignedTo: string;
  comments: string[];
  feedback: alertFeedback;
  status: alertStatus;
  updatedDateTime: Date;
  user: string
}
