import { entity } from './entity.interface';

export interface deviceManagementTroubleshootingEvent extends entity {
  eventDateTime: Date;
  correlationId: string
}
