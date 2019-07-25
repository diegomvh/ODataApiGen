
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Product_Sales_for_1997 extends ODataModel {
  static type = 'NorthwindModel.Product_Sales_for_1997';
  static schema = Schema.create({
    keys: [
        'CategoryName', 'ProductName'
    ],
    fields: [
      {name: 'CategoryName', required: true, type: 'String', length: 15},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'ProductSales', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  CategoryName: string;
  ProductName: string;
  ProductSales: number;

  
}