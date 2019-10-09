import { identitySet } from './identityset.interface';

export interface plannerChecklistItem {
  isChecked: boolean;
  title: string;
  orderHint: string;
  lastModifiedBy: identitySet;
  lastModifiedDateTime: Date
}
