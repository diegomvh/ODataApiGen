import { entity } from './entity.interface';
import { teamsApp } from './teamsapp.interface';
import { teamsAppDefinition } from './teamsappdefinition.interface';

export interface teamsAppInstallation extends entity {
  teamsApp?: teamsApp;
  teamsAppDefinition?: teamsAppDefinition
}
