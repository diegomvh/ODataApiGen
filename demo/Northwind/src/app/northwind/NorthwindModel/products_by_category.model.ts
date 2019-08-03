
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Products_by_Category extends ODataModel {
  static type = 'NorthwindModel.Products_by_Category';
  static schema = Schema.create({
    keys: [
      {name: 'CategoryName'},
      {name: 'Discontinued'},
      {name: 'ProductName'}
    ],
    fields: [
      {name: 'CategoryName', type: 'String', required: true, length: 15},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'QuantityPerUnit', type: 'String', required: true, length: 20},
      {name: 'UnitsInStock', type: 'Number', required: true},
      {name: 'Discontinued', type: 'Boolean', required: true}
    ]
  });
  CategoryName: string;
  ProductName: string;
  QuantityPerUnit: string;
  UnitsInStock: number;
  Discontinued: boolean;

  
}