import { Customer } from './customer.model';
import { Employee } from './employee.model';
import { Order_Detail } from './order_detail.model';
import { Shipper } from './shipper.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Order extends ODataModel {
  static type = 'NorthwindModel.Order';
  static schema = Schema.create({
    keys: [
        'OrderID'
    ],
    fields: [
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'CustomerID', required: true, type: 'String', length: 5},
      {name: 'EmployeeID', required: true, type: 'Number'},
      {name: 'OrderDate', required: true, type: 'Date'},
      {name: 'RequiredDate', required: true, type: 'Date'},
      {name: 'ShippedDate', required: true, type: 'Date'},
      {name: 'ShipVia', required: true, type: 'Number'},
      {name: 'Freight', required: true, type: 'Number'},
      {name: 'ShipName', required: true, type: 'String', length: 40},
      {name: 'ShipAddress', required: true, type: 'String', length: 60},
      {name: 'ShipCity', required: true, type: 'String', length: 15},
      {name: 'ShipRegion', required: true, type: 'String', length: 15},
      {name: 'ShipPostalCode', required: true, type: 'String', length: 10},
      {name: 'ShipCountry', required: true, type: 'String', length: 15},
      {name: 'Customer', required: false, type: 'NorthwindModel.Customer'},
      {name: 'Employee', required: false, type: 'NorthwindModel.Employee'},
      {name: 'Order_Details', required: false, type: 'NorthwindModel.Order_DetailCollection'},
      {name: 'Shipper', required: false, type: 'NorthwindModel.Shipper'}
    ],
    defaults: {}
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

  public getCustomer(): Customer {
    return this.relatedODataModel('Customer') as Customer;
  }
  public setCustomerAsCustomer(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Customer', target, options);
  }
  public unsetCustomerAsCustomer(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Customer', target, options);
  }
  public getEmployee(): Employee {
    return this.relatedODataModel('Employee') as Employee;
  }
  public setEmployeeAsEmployee(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Employee', target, options);
  }
  public unsetEmployeeAsEmployee(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Employee', target, options);
  }
  public getOrder_Details(): ODataCollection<Order_Detail> {
    return this.relatedODataCollection('Order_Details') as ODataCollection<Order_Detail>;
  }
  public addOrder_DetailToOrder_Details(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Order_Details', target, options);
  }
  public removeOrder_DetailFromOrder_Details(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Order_Details', target, options);
  }
  public getShipper(): Shipper {
    return this.relatedODataModel('Shipper') as Shipper;
  }
  public setShipperAsShipper(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Shipper', target, options);
  }
  public unsetShipperAsShipper(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Shipper', target, options);
  }
}