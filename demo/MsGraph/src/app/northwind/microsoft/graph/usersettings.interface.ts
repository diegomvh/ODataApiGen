import { entity } from './entity.interface';

export interface userSettings extends entity {
  contributionToContentDiscoveryDisabled: boolean;
  contributionToContentDiscoveryAsOrganizationDisabled: boolean
}
