import { actionState } from './actionstate.enum';

export interface deviceActionResult {
  actionName: string;
  actionState: actionState;
  startDateTime: Date;
  lastUpdatedDateTime: Date
}
