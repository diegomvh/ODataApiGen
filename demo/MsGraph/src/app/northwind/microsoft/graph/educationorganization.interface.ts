import { educationExternalSource } from './educationexternalsource.enum';
import { entity } from './entity.interface';

export interface educationOrganization extends entity {
  displayName: string;
  description: string;
  externalSource: educationExternalSource
}
