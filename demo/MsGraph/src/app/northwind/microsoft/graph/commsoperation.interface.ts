import { operationStatus } from './operationstatus.enum';
import { resultInfo } from './resultinfo.interface';
import { entity } from './entity.interface';

export interface commsOperation extends entity {
  status: operationStatus;
  clientContext: string;
  resultInfo: resultInfo
}
