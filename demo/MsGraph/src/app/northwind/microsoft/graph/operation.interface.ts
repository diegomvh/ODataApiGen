import { operationStatus } from './operationstatus.enum';
import { entity } from './entity.interface';

export interface operation extends entity {
  status: operationStatus;
  createdDateTime: Date;
  lastActionDateTime: Date
}
