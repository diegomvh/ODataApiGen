import { entity } from './entity.interface';

export interface teamsAppDefinition extends entity {
  teamsAppId: string;
  displayName: string;
  version: string
}
