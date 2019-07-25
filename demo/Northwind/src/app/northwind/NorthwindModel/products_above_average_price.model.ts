
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Products_Above_Average_Price extends ODataModel {
  static type = 'NorthwindModel.Products_Above_Average_Price';
  static schema = Schema.create({
    keys: [
        'ProductName'
    ],
    fields: [
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'UnitPrice', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  ProductName: string;
  UnitPrice: number;

  
}