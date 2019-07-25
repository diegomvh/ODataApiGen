
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Category_Sales_for_1997 extends ODataModel {
  static type = 'NorthwindModel.Category_Sales_for_1997';
  static schema = Schema.create({
    keys: [
        'CategoryName'
    ],
    fields: [
      {name: 'CategoryName', required: true, type: 'String', length: 15},
      {name: 'CategorySales', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  CategoryName: string;
  CategorySales: number;

  
}