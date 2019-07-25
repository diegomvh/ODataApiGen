
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Alphabetical_list_of_product extends ODataModel {
  static type = 'NorthwindModel.Alphabetical_list_of_product';
  static schema = Schema.create({
    keys: [
        'CategoryName', 'Discontinued', 'ProductID', 'ProductName'
    ],
    fields: [
      {name: 'ProductID', required: true, type: 'Number'},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'SupplierID', required: true, type: 'Number'},
      {name: 'CategoryID', required: true, type: 'Number'},
      {name: 'QuantityPerUnit', required: true, type: 'String', length: 20},
      {name: 'UnitPrice', required: true, type: 'Number'},
      {name: 'UnitsInStock', required: true, type: 'Number'},
      {name: 'UnitsOnOrder', required: true, type: 'Number'},
      {name: 'ReorderLevel', required: true, type: 'Number'},
      {name: 'Discontinued', required: true, type: 'Boolean'},
      {name: 'CategoryName', required: true, type: 'String', length: 15}
    ],
    defaults: {}
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