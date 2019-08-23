import { Order } from './order.model';
import { Territory } from './territory.model';
import { EmployeeCollection } from './employee.collection';
import { OrderCollection } from './order.collection';
import { TerritoryCollection } from './territory.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Employee extends ODataModel {
  static type = 'NorthwindModel.Employee';
  static schema = Schema.create({
    keys: [
      {name: 'EmployeeID'}
    ],
    fields: [
      {name: 'EmployeeID', type: 'Number', required: true},
      {name: 'LastName', type: 'String', required: true, length: 20},
      {name: 'FirstName', type: 'String', required: true, length: 10},
      {name: 'Title', type: 'String', required: true, length: 30},
      {name: 'TitleOfCourtesy', type: 'String', required: true, length: 25},
      {name: 'BirthDate', type: 'Date', required: true},
      {name: 'HireDate', type: 'Date', required: true},
      {name: 'Address', type: 'String', required: true, length: 60},
      {name: 'City', type: 'String', required: true, length: 15},
      {name: 'Region', type: 'String', required: true, length: 15},
      {name: 'PostalCode', type: 'String', required: true, length: 10},
      {name: 'Country', type: 'String', required: true, length: 15},
      {name: 'HomePhone', type: 'String', required: true, length: 24},
      {name: 'Extension', type: 'String', required: true, length: 4},
      {name: 'Photo', type: 'String', required: true},
      {name: 'Notes', type: 'String', required: true},
      {name: 'ReportsTo', type: 'Number', required: true},
      {name: 'PhotoPath', type: 'String', required: true, length: 255},
      {name: 'Employees1', type: 'NorthwindModel.EmployeeCollection', ctor: true, related: true, collection: true},
      {name: 'Employee1', type: 'NorthwindModel.Employee'},
      {name: 'Orders', type: 'NorthwindModel.OrderCollection', ctor: true, related: true, collection: true},
      {name: 'Territories', type: 'NorthwindModel.TerritoryCollection', ctor: true, related: true, collection: true}
    ]
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
  Employees1?: EmployeeCollection;
  Employee1?: Employee;
  Orders?: OrderCollection;
  Territories?: TerritoryCollection;

  
}