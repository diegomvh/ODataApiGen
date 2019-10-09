import { entity } from './entity.interface';
import { inferenceClassificationOverride } from './inferenceclassificationoverride.interface';

export interface inferenceClassification extends entity {
  overrides?: inferenceClassificationOverride[]
}
