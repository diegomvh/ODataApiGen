import { teamsAppDistributionMethod } from './teamsappdistributionmethod.enum';
import { entity } from './entity.interface';
import { teamsAppDefinition } from './teamsappdefinition.interface';

export interface teamsApp extends entity {
  externalId: string;
  displayName: string;
  distributionMethod: teamsAppDistributionMethod;
  appDefinitions?: teamsAppDefinition[]
}
