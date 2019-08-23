
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Products_Above_Average_Price extends ODataModel {
  static type = 'NorthwindModel.Products_Above_Average_Price';
  static schema = Schema.create({
    keys: [
      {name: 'ProductName'}
    ],
    fields: [
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'UnitPrice', type: 'Number', required: true}
    ]
  });
  ProductName: string;
  UnitPrice: number;

  
}