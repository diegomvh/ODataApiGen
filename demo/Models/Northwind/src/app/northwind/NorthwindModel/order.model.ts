import { Customer } from './customer.model';
import { Employee } from './employee.model';
import { Order_Detail } from './order_detail.model';
import { Shipper } from './shipper.model';
import { CustomerCollection } from './customer.collection';
import { EmployeeCollection } from './employee.collection';
import { Order_DetailCollection } from './order_detail.collection';
import { ShipperCollection } from './shipper.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Order extends ODataModel {
  static type = 'NorthwindModel.Order';
  static schema = Schema.create({
    keys: [
      {name: 'OrderID'}
    ],
    fields: [
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'CustomerID', type: 'String', required: true, length: 5},
      {name: 'EmployeeID', type: 'Number', required: true},
      {name: 'OrderDate', type: 'Date', required: true},
      {name: 'RequiredDate', type: 'Date', required: true},
      {name: 'ShippedDate', type: 'Date', required: true},
      {name: 'ShipVia', type: 'Number', required: true},
      {name: 'Freight', type: 'Number', required: true},
      {name: 'ShipName', type: 'String', required: true, length: 40},
      {name: 'ShipAddress', type: 'String', required: true, length: 60},
      {name: 'ShipCity', type: 'String', required: true, length: 15},
      {name: 'ShipRegion', type: 'String', required: true, length: 15},
      {name: 'ShipPostalCode', type: 'String', required: true, length: 10},
      {name: 'ShipCountry', type: 'String', required: true, length: 15},
      {name: 'Customer', type: 'NorthwindModel.Customer', ctor: true, related: true},
      {name: 'Employee', type: 'NorthwindModel.Employee', ctor: true, related: true},
      {name: 'Order_Details', type: 'NorthwindModel.Order_DetailCollection', ctor: true, related: true, collection: true},
      {name: 'Shipper', type: 'NorthwindModel.Shipper', ctor: true, related: true}
    ]
  });
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
  Order_Details?: Order_DetailCollection;
  Shipper?: Shipper;

  
}