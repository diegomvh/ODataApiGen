
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Current_Product_List extends ODataModel {
  static type = 'NorthwindModel.Current_Product_List';
  static schema = Schema.create({
    keys: [
      {name: 'ProductID'},
      {name: 'ProductName'}
    ],
    fields: [
      {name: 'ProductID', type: 'Number', required: true},
      {name: 'ProductName', type: 'String', required: true, length: 40}
    ]
  });
  ProductID: number;
  ProductName: string;

  
}