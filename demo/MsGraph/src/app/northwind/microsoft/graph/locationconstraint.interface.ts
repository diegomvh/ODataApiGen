import { locationConstraintItem } from './locationconstraintitem.interface';

export interface locationConstraint {
  locations: locationConstraintItem[];
  isRequired: boolean;
  suggestLocation: boolean
}
