
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Orders_Qry extends ODataModel {
  static type = 'NorthwindModel.Orders_Qry';
  static schema = Schema.create({
    keys: [
        'CompanyName', 'OrderID'
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
      {name: 'CompanyName', required: true, type: 'String', length: 40},
      {name: 'Address', required: true, type: 'String', length: 60},
      {name: 'City', required: true, type: 'String', length: 15},
      {name: 'Region', required: true, type: 'String', length: 15},
      {name: 'PostalCode', required: true, type: 'String', length: 10},
      {name: 'Country', required: true, type: 'String', length: 15}
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
  CompanyName: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;

  
}