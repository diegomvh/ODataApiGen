
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Alphabetical_list_of_product extends ODataModel {
  static type = 'NorthwindModel.Alphabetical_list_of_product';
  static schema = Schema.create({
    keys: [
      {name: 'CategoryName'},
      {name: 'Discontinued'},
      {name: 'ProductID'},
      {name: 'ProductName'}
    ],
    fields: [
      {name: 'ProductID', type: 'Number', required: true},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'SupplierID', type: 'Number', required: true},
      {name: 'CategoryID', type: 'Number', required: true},
      {name: 'QuantityPerUnit', type: 'String', required: true, length: 20},
      {name: 'UnitPrice', type: 'Number', required: true},
      {name: 'UnitsInStock', type: 'Number', required: true},
      {name: 'UnitsOnOrder', type: 'Number', required: true},
      {name: 'ReorderLevel', type: 'Number', required: true},
      {name: 'Discontinued', type: 'Boolean', required: true},
      {name: 'CategoryName', type: 'String', required: true, length: 15}
    ]
  });
  ProductID: number;
  ProductName: string;
  SupplierID: number;
  CategoryID: number;
  QuantityPerUnit: string;
  UnitPrice: number;
  UnitsInStock: number;
  UnitsOnOrder: number;
  ReorderLevel: number;
  Discontinued: boolean;
  CategoryName: string;

  
}