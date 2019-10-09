import { entity } from './entity.interface';

export interface resourceOperation extends entity {
  resourceName: string;
  actionName: string;
  description: string
}
