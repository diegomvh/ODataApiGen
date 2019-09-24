import { Customer } from './customer.interface';
import { Employee } from './employee.interface';
import { Order_Detail } from './order_detail.interface';
import { Shipper } from './shipper.interface';

export interface Order {
  OrderID: number;
  CustomerID: string;
  EmployeeID: number;
  OrderDate: Date;
  RequiredDate: Date;
  ShippedDate: Date;
  ShipVia: number;
  Freight: number;
  ShipName: string;
  ShipAddress: string;
  ShipCity: string;
  ShipRegion: string;
  ShipPostalCode: string;
  ShipCountry: string;
  Customer?: Customer;
  Employee?: Employee;
  Order_Details?: Order_Detail[];
  Shipper?: Shipper;
}