import { teamsTabConfiguration } from './teamstabconfiguration.interface';
import { entity } from './entity.interface';
import { teamsApp } from './teamsapp.interface';

export interface teamsTab extends entity {
  displayName: string;
  webUrl: string;
  configuration: teamsTabConfiguration;
  teamsApp?: teamsApp
}
