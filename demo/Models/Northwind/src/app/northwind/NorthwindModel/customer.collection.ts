import { Customer } from './customer.model';
import { Collection, ODataCollection } from 'angular-odata';

export class CustomerCollection extends ODataCollection<Customer> {
  static type = 'NorthwindModel.CustomerCollection';
  static modelType = 'NorthwindModel.Customer';
}