import { entity } from './entity.interface';
import { trending } from './trending.interface';
import { sharedInsight } from './sharedinsight.interface';
import { usedInsight } from './usedinsight.interface';

export interface officeGraphInsights extends entity {
  trending?: trending[];
  shared?: sharedInsight[];
  used?: usedInsight[]
}
