import { Customer } from './customer.interface';

export interface CustomerDemographic {
  CustomerTypeID: string;
  CustomerDesc: string;
  Customers?: Customer[];
}