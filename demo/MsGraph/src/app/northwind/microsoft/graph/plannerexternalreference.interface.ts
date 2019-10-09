import { identitySet } from './identityset.interface';

export interface plannerExternalReference {
  alias: string;
  type: string;
  previewPriority: string;
  lastModifiedBy: identitySet;
  lastModifiedDateTime: Date
}
