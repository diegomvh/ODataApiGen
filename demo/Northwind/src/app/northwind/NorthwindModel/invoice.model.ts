
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Invoice extends ODataModel {
  static type = 'NorthwindModel.Invoice';
  static schema = Schema.create({
    keys: [
        'CustomerName', 'Discount', 'OrderID', 'ProductID', 'ProductName', 'Quantity', 'Salesperson', 'ShipperName', 'UnitPrice'
    ],
    fields: [
      {name: 'ShipName', required: true, type: 'String', length: 40},
      {name: 'ShipAddress', required: true, type: 'String', length: 60},
      {name: 'ShipCity', required: true, type: 'String', length: 15},
      {name: 'ShipRegion', required: true, type: 'String', length: 15},
      {name: 'ShipPostalCode', required: true, type: 'String', length: 10},
      {name: 'ShipCountry', required: true, type: 'String', length: 15},
      {name: 'CustomerID', required: true, type: 'String', length: 5},
      {name: 'CustomerName', required: true, type: 'String', length: 40},
      {name: 'Address', required: true, type: 'String', length: 60},
      {name: 'City', required: true, type: 'String', length: 15},
      {name: 'Region', required: true, type: 'String', length: 15},
      {name: 'PostalCode', required: true, type: 'String', length: 10},
      {name: 'Country', required: true, type: 'String', length: 15},
      {name: 'Salesperson', required: true, type: 'String', length: 31},
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'OrderDate', required: true, type: 'Date'},
      {name: 'RequiredDate', required: true, type: 'Date'},
      {name: 'ShippedDate', required: true, type: 'Date'},
      {name: 'ShipperName', required: true, type: 'String', length: 40},
      {name: 'ProductID', required: true, type: 'Number'},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'UnitPrice', required: true, type: 'Number'},
      {name: 'Quantity', required: true, type: 'Number'},
      {name: 'Discount', required: true, type: 'Number'},
      {name: 'ExtendedPrice', required: true, type: 'Number'},
      {name: 'Freight', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  ShipName: string;
  ShipAddress: string;
  ShipCity: string;
  ShipRegion: string;
  ShipPostalCode: string;
  ShipCountry: string;
  CustomerID: string;
  CustomerName: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;
  Salesperson: string;
  OrderID: number;
  OrderDate: Date;
  RequiredDate: Date;
  ShippedDate: Date;
  ShipperName: string;
  ProductID: number;
  ProductName: string;
  UnitPrice: number;
  Quantity: number;
  Discount: number;
  ExtendedPrice: number;
  Freight: number;

  
}