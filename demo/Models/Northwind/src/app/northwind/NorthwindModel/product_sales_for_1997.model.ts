
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Product_Sales_for_1997 extends ODataModel {
  static type = 'NorthwindModel.Product_Sales_for_1997';
  static schema = Schema.create({
    keys: [
      {name: 'CategoryName'},
      {name: 'ProductName'}
    ],
    fields: [
      {name: 'CategoryName', type: 'String', required: true, length: 15},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'ProductSales', type: 'Number', required: true}
    ]
  });
  CategoryName: string;
  ProductName: string;
  ProductSales: number;

  
}