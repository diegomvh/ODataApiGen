import { servicePlanInfo } from './serviceplaninfo.interface';
import { entity } from './entity.interface';

export interface licenseDetails extends entity {
  servicePlans: servicePlanInfo[];
  skuId: string;
  skuPartNumber: string
}
