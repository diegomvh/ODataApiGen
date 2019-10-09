import { dataPolicyOperationStatus } from './datapolicyoperationstatus.enum';
import { entity } from './entity.interface';

export interface dataPolicyOperation extends entity {
  completedDateTime: Date;
  status: dataPolicyOperationStatus;
  storageLocation: string;
  userId: string;
  submittedDateTime: Date;
  progress: number
}
