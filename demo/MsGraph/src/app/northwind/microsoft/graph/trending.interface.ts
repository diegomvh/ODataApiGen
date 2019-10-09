import { resourceVisualization } from './resourcevisualization.interface';
import { resourceReference } from './resourcereference.interface';
import { entity } from './entity.interface';

export interface trending extends entity {
  weight: number;
  resourceVisualization: resourceVisualization;
  resourceReference: resourceReference;
  lastModifiedDateTime: Date;
  resource?: entity
}
