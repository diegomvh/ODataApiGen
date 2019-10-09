import { teamsAsyncOperationType } from './teamsasyncoperationtype.enum';
import { teamsAsyncOperationStatus } from './teamsasyncoperationstatus.enum';
import { operationError } from './operationerror.interface';
import { entity } from './entity.interface';

export interface teamsAsyncOperation extends entity {
  operationType: teamsAsyncOperationType;
  createdDateTime: Date;
  status: teamsAsyncOperationStatus;
  lastActionDateTime: Date;
  attemptsCount: number;
  targetResourceId: string;
  targetResourceLocation: string;
  error: operationError
}
