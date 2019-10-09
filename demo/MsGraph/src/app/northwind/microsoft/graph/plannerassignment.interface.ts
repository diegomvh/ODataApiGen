import { identitySet } from './identityset.interface';

export interface plannerAssignment {
  assignedBy: identitySet;
  assignedDateTime: Date;
  orderHint: string
}
