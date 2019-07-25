import { Order } from './order.model';
import { Territory } from './territory.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Employee extends ODataModel {
  static type = 'NorthwindModel.Employee';
  static schema = Schema.create({
    keys: [
        'EmployeeID'
    ],
    fields: [
      {name: 'EmployeeID', required: true, type: 'Number'},
      {name: 'LastName', required: true, type: 'String', length: 20},
      {name: 'FirstName', required: true, type: 'String', length: 10},
      {name: 'Title', required: true, type: 'String', length: 30},
      {name: 'TitleOfCourtesy', required: true, type: 'String', length: 25},
      {name: 'BirthDate', required: true, type: 'Date'},
      {name: 'HireDate', required: true, type: 'Date'},
      {name: 'Address', required: true, type: 'String', length: 60},
      {name: 'City', required: true, type: 'String', length: 15},
      {name: 'Region', required: true, type: 'String', length: 15},
      {name: 'PostalCode', required: true, type: 'String', length: 10},
      {name: 'Country', required: true, type: 'String', length: 15},
      {name: 'HomePhone', required: true, type: 'String', length: 24},
      {name: 'Extension', required: true, type: 'String', length: 4},
      {name: 'Photo', required: true, type: 'String'},
      {name: 'Notes', required: true, type: 'String'},
      {name: 'ReportsTo', required: true, type: 'Number'},
      {name: 'PhotoPath', required: true, type: 'String', length: 255},
      {name: 'Employees1', required: false, type: 'NorthwindModel.EmployeeCollection'},
      {name: 'Employee1', required: false, type: 'NorthwindModel.Employee'},
      {name: 'Orders', required: false, type: 'NorthwindModel.OrderCollection'},
      {name: 'Territories', required: false, type: 'NorthwindModel.TerritoryCollection'}
    ],
    defaults: {}
  });
  EmployeeID: number;
  LastName: string;
  FirstName: string;
  Title: string;
  TitleOfCourtesy: string;
  BirthDate: Date;
  HireDate: Date;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;
  HomePhone: string;
  Extension: string;
  Photo: string;
  Notes: string;
  ReportsTo: number;
  PhotoPath: string;

  public getEmployees1(): ODataCollection<Employee> {
    return this.relatedODataCollection('Employees1') as ODataCollection<Employee>;
  }
  public addEmployeeToEmployees1(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Employees1', target, options);
  }
  public removeEmployeeFromEmployees1(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Employees1', target, options);
  }
  public getEmployee1(): Employee {
    return this.relatedODataModel('Employee1') as Employee;
  }
  public setEmployeeAsEmployee1(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Employee1', target, options);
  }
  public unsetEmployeeAsEmployee1(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Employee1', target, options);
  }
  public getOrders(): ODataCollection<Order> {
    return this.relatedODataCollection('Orders') as ODataCollection<Order>;
  }
  public addOrderToOrders(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Orders', target, options);
  }
  public removeOrderFromOrders(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Orders', target, options);
  }
  public getTerritories(): ODataCollection<Territory> {
    return this.relatedODataCollection('Territories') as ODataCollection<Territory>;
  }
  public addTerritoryToTerritories(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Territories', target, options);
  }
  public removeTerritoryFromTerritories(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Territories', target, options);
  }
}