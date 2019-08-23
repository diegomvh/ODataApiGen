
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Invoice extends ODataModel {
  static type = 'NorthwindModel.Invoice';
  static schema = Schema.create({
    keys: [
      {name: 'CustomerName'},
      {name: 'Discount'},
      {name: 'OrderID'},
      {name: 'ProductID'},
      {name: 'ProductName'},
      {name: 'Quantity'},
      {name: 'Salesperson'},
      {name: 'ShipperName'},
      {name: 'UnitPrice'}
    ],
    fields: [
      {name: 'ShipName', type: 'String', required: true, length: 40},
      {name: 'ShipAddress', type: 'String', required: true, length: 60},
      {name: 'ShipCity', type: 'String', required: true, length: 15},
      {name: 'ShipRegion', type: 'String', required: true, length: 15},
      {name: 'ShipPostalCode', type: 'String', required: true, length: 10},
      {name: 'ShipCountry', type: 'String', required: true, length: 15},
      {name: 'CustomerID', type: 'String', required: true, length: 5},
      {name: 'CustomerName', type: 'String', required: true, length: 40},
      {name: 'Address', type: 'String', required: true, length: 60},
      {name: 'City', type: 'String', required: true, length: 15},
      {name: 'Region', type: 'String', required: true, length: 15},
      {name: 'PostalCode', type: 'String', required: true, length: 10},
      {name: 'Country', type: 'String', required: true, length: 15},
      {name: 'Salesperson', type: 'String', required: true, length: 31},
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'OrderDate', type: 'Date', required: true},
      {name: 'RequiredDate', type: 'Date', required: true},
      {name: 'ShippedDate', type: 'Date', required: true},
      {name: 'ShipperName', type: 'String', required: true, length: 40},
      {name: 'ProductID', type: 'Number', required: true},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'UnitPrice', type: 'Number', required: true},
      {name: 'Quantity', type: 'Number', required: true},
      {name: 'Discount', type: 'Number', required: true},
      {name: 'ExtendedPrice', type: 'Number', required: true},
      {name: 'Freight', type: 'Number', required: true}
    ]
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