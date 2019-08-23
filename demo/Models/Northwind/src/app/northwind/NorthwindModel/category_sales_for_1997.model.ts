
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Category_Sales_for_1997 extends ODataModel {
  static type = 'NorthwindModel.Category_Sales_for_1997';
  static schema = Schema.create({
    keys: [
      {name: 'CategoryName'}
    ],
    fields: [
      {name: 'CategoryName', type: 'String', required: true, length: 15},
      {name: 'CategorySales', type: 'Number', required: true}
    ]
  });
  CategoryName: string;
  CategorySales: number;

  
}