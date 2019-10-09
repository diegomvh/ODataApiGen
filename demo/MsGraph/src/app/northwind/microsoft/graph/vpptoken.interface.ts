import { vppTokenAccountType } from './vpptokenaccounttype.enum';
import { vppTokenState } from './vpptokenstate.enum';
import { vppTokenSyncStatus } from './vpptokensyncstatus.enum';
import { entity } from './entity.interface';

export interface vppToken extends entity {
  organizationName: string;
  vppTokenAccountType: vppTokenAccountType;
  appleId: string;
  expirationDateTime: Date;
  lastSyncDateTime: Date;
  token: string;
  lastModifiedDateTime: Date;
  state: vppTokenState;
  lastSyncStatus: vppTokenSyncStatus;
  automaticallyUpdateApps: boolean;
  countryOrRegion: string
}
