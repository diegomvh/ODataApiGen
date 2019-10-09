import { baseItemVersion } from './baseitemversion.interface';
import { fieldValueSet } from './fieldvalueset.interface';

export interface listItemVersion extends baseItemVersion {
  fields?: fieldValueSet
}
