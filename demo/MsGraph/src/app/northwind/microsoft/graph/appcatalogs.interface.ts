import { entity } from './entity.interface';
import { teamsApp } from './teamsapp.interface';

export interface appCatalogs extends entity {
  teamsApps?: teamsApp[]
}
