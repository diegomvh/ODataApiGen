import { identitySet } from './identityset.interface';

export interface sharingInvitation {
  email: string;
  invitedBy: identitySet;
  redeemedBy: string;
  signInRequired: boolean
}
