import { mobileThreatPartnerTenantState } from './mobilethreatpartnertenantstate.enum';
import { entity } from './entity.interface';

export interface mobileThreatDefenseConnector extends entity {
  lastHeartbeatDateTime: Date;
  partnerState: mobileThreatPartnerTenantState;
  androidEnabled: boolean;
  iosEnabled: boolean;
  androidDeviceBlockedOnMissingPartnerData: boolean;
  iosDeviceBlockedOnMissingPartnerData: boolean;
  partnerUnsupportedOsVersionBlocked: boolean;
  partnerUnresponsivenessThresholdInDays: number
}
