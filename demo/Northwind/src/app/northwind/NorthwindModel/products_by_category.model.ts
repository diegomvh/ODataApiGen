
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Products_by_Category extends ODataModel {
  static type = 'NorthwindModel.Products_by_Category';
  static schema = Schema.create({
    keys: [
        'CategoryName', 'Discontinued', 'ProductName'
    ],
    fields: [
      {name: 'CategoryName', required: true, type: 'String', length: 15},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'QuantityPerUnit', required: true, type: 'String', length: 20},
      {name: 'UnitsInStock', required: true, type: 'Number'},
      {name: 'Discontinued', required: true, type: 'Boolean'}
    ],
    defaults: {}
  });
  CategoryName: string;
  ProductName: string;
  QuantityPerUnit: string;
  UnitsInStock: number;
  Discontinued: boolean;

  
}