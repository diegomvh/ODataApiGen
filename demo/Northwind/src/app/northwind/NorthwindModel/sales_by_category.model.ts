
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Sales_by_Category extends ODataModel {
  static type = 'NorthwindModel.Sales_by_Category';
  static schema = Schema.create({
    keys: [
        'CategoryID', 'CategoryName', 'ProductName'
    ],
    fields: [
      {name: 'CategoryID', required: true, type: 'Number'},
      {name: 'CategoryName', required: true, type: 'String', length: 15},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'ProductSales', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  CategoryID: number;
  CategoryName: string;
  ProductName: string;
  ProductSales: number;

  
}