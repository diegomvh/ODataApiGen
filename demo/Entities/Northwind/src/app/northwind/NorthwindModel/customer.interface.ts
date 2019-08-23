import { CustomerDemographic } from './customerdemographic.interface';
import { Order } from './order.interface';

export interface Customer {
  CustomerID: string;
  CompanyName: string;
  ContactName: string;
  ContactTitle: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;
  Phone: string;
  Fax: string;
  Orders?: Order[];
  CustomerDemographics?: CustomerDemographic[];
}