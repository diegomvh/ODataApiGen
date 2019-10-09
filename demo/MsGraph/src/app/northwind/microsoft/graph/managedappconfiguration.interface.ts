import { keyValuePair } from './keyvaluepair.interface';
import { managedAppPolicy } from './managedapppolicy.interface';

export interface managedAppConfiguration extends managedAppPolicy {
  customSettings: keyValuePair[]
}
