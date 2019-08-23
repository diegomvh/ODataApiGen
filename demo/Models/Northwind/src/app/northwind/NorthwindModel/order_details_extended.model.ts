
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Order_Details_Extended extends ODataModel {
  static type = 'NorthwindModel.Order_Details_Extended';
  static schema = Schema.create({
    keys: [
      {name: 'Discount'},
      {name: 'OrderID'},
      {name: 'ProductID'},
      {name: 'ProductName'},
      {name: 'Quantity'},
      {name: 'UnitPrice'}
    ],
    fields: [
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'ProductID', type: 'Number', required: true},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'UnitPrice', type: 'Number', required: true},
      {name: 'Quantity', type: 'Number', required: true},
      {name: 'Discount', type: 'Number', required: true},
      {name: 'ExtendedPrice', type: 'Number', required: true}
    ]
  });
  OrderID: number;
  ProductID: number;
  ProductName: string;
  UnitPrice: number;
  Quantity: number;
  Discount: number;
  ExtendedPrice: number;

  
}