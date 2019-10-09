import { resourceVisualization } from './resourcevisualization.interface';
import { resourceReference } from './resourcereference.interface';
import { sharingDetail } from './sharingdetail.interface';
import { entity } from './entity.interface';

export interface sharedInsight extends entity {
  lastShared: sharingDetail;
  sharingHistory: sharingDetail[];
  resourceVisualization: resourceVisualization;
  resourceReference: resourceReference;
  lastSharedMethod?: entity;
  resource?: entity
}
