import { operationResult } from './operationresult.enum';
import { auditActivityInitiator } from './auditactivityinitiator.interface';
import { targetResource } from './targetresource.interface';
import { keyValue } from './keyvalue.interface';
import { entity } from './entity.interface';

export interface directoryAudit extends entity {
  category: string;
  correlationId: string;
  result: operationResult;
  resultReason: string;
  activityDisplayName: string;
  activityDateTime: Date;
  loggedByService: string;
  operationType: string;
  initiatedBy: auditActivityInitiator;
  targetResources: targetResource[];
  additionalDetails: keyValue[]
}
