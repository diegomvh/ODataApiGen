import { identity } from './identity.interface';

export interface sharingLink {
  application: identity;
  scope: string;
  type: string;
  webUrl: string
}
