import { entity } from './entity.interface';
import { teamsTab } from './teamstab.interface';

export interface channel extends entity {
  displayName: string;
  description: string;
  email: string;
  webUrl: string;
  tabs?: teamsTab[]
}
