import { entity } from './entity.interface';

export interface identityProvider extends entity {
  type: string;
  name: string;
  clientId: string;
  clientSecret: string
}
