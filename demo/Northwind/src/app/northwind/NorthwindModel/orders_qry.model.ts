
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Orders_Qry extends ODataModel {
  static type = 'NorthwindModel.Orders_Qry';
  static schema = Schema.create({
    keys: [
      {name: 'CompanyName'},
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
      {name: 'CompanyName', type: 'String', required: true, length: 40},
      {name: 'Address', type: 'String', required: true, length: 60},
      {name: 'City', type: 'String', required: true, length: 15},
      {name: 'Region', type: 'String', required: true, length: 15},
      {name: 'PostalCode', type: 'String', required: true, length: 10},
      {name: 'Country', type: 'String', required: true, length: 15}
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
  CompanyName: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;

  
}