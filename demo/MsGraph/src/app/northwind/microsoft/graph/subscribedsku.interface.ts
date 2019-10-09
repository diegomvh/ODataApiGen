import { servicePlanInfo } from './serviceplaninfo.interface';
import { licenseUnitsDetail } from './licenseunitsdetail.interface';
import { entity } from './entity.interface';

export interface subscribedSku extends entity {
  capabilityStatus: string;
  consumedUnits: number;
  prepaidUnits: licenseUnitsDetail;
  servicePlans: servicePlanInfo[];
  skuId: string;
  skuPartNumber: string;
  appliesTo: string
}
