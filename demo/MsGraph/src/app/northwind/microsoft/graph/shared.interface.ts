import { identitySet } from './identityset.interface';

export interface shared {
  owner: identitySet;
  scope: string;
  sharedBy: identitySet;
  sharedDateTime: Date
}
