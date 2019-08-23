
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Sales_by_Category extends ODataModel {
  static type = 'NorthwindModel.Sales_by_Category';
  static schema = Schema.create({
    keys: [
      {name: 'CategoryID'},
      {name: 'CategoryName'},
      {name: 'ProductName'}
    ],
    fields: [
      {name: 'CategoryID', type: 'Number', required: true},
      {name: 'CategoryName', type: 'String', required: true, length: 15},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'ProductSales', type: 'Number', required: true}
    ]
  });
  CategoryID: number;
  CategoryName: string;
  ProductName: string;
  ProductSales: number;

  
}