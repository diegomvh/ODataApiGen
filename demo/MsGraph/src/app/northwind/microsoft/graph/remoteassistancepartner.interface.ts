import { remoteAssistanceOnboardingStatus } from './remoteassistanceonboardingstatus.enum';
import { entity } from './entity.interface';

export interface remoteAssistancePartner extends entity {
  displayName: string;
  onboardingUrl: string;
  onboardingStatus: remoteAssistanceOnboardingStatus;
  lastConnectionDateTime: Date
}
