import { deviceManagementPartnerTenantState } from './devicemanagementpartnertenantstate.enum';
import { deviceManagementPartnerAppType } from './devicemanagementpartnerapptype.enum';
import { entity } from './entity.interface';

export interface deviceManagementPartner extends entity {
  lastHeartbeatDateTime: Date;
  partnerState: deviceManagementPartnerTenantState;
  partnerAppType: deviceManagementPartnerAppType;
  singleTenantAppId: string;
  displayName: string;
  isConfigured: boolean;
  whenPartnerDevicesWillBeRemovedDateTime: Date;
  whenPartnerDevicesWillBeMarkedAsNonCompliantDateTime: Date
}
