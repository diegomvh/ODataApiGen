import { certificationControl } from './certificationcontrol.interface';

export interface complianceInformation {
  certificationControls: certificationControl[];
  certificationName: string
}
