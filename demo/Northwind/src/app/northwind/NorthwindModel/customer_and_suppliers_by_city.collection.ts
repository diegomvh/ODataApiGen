import { Customer_and_Suppliers_by_City } from './customer_and_suppliers_by_city.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Customer_and_Suppliers_by_CityCollection extends ODataCollection<Customer_and_Suppliers_by_City> {
  static type = 'NorthwindModel.Customer_and_Suppliers_by_CityCollection';
  static model = 'NorthwindModel.Customer_and_Suppliers_by_City';
}