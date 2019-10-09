import { onenoteOperationError } from './onenoteoperationerror.interface';
import { operation } from './operation.interface';

export interface onenoteOperation extends operation {
  resourceLocation: string;
  resourceId: string;
  error: onenoteOperationError;
  percentComplete: string
}
