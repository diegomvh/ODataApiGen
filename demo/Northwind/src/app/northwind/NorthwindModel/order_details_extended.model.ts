
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Order_Details_Extended extends ODataModel {
  static type = 'NorthwindModel.Order_Details_Extended';
  static schema = Schema.create({
    keys: [
        'Discount', 'OrderID', 'ProductID', 'ProductName', 'Quantity', 'UnitPrice'
    ],
    fields: [
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'ProductID', required: true, type: 'Number'},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'UnitPrice', required: true, type: 'Number'},
      {name: 'Quantity', required: true, type: 'Number'},
      {name: 'Discount', required: true, type: 'Number'},
      {name: 'ExtendedPrice', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  OrderID: number;
  ProductID: number;
  ProductName: string;
  UnitPrice: number;
  Quantity: number;
  Discount: number;
  ExtendedPrice: number;

  
}