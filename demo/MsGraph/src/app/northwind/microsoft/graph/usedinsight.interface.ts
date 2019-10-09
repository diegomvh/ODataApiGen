import { resourceVisualization } from './resourcevisualization.interface';
import { resourceReference } from './resourcereference.interface';
import { usageDetails } from './usagedetails.interface';
import { entity } from './entity.interface';

export interface usedInsight extends entity {
  lastUsed: usageDetails;
  resourceVisualization: resourceVisualization;
  resourceReference: resourceReference;
  resource?: entity
}
