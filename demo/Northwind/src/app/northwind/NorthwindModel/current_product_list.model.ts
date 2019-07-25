
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Current_Product_List extends ODataModel {
  static type = 'NorthwindModel.Current_Product_List';
  static schema = Schema.create({
    keys: [
        'ProductID', 'ProductName'
    ],
    fields: [
      {name: 'ProductID', required: true, type: 'Number'},
      {name: 'ProductName', required: true, type: 'String', length: 40}
    ],
    defaults: {}
  });
  ProductID: number;
  ProductName: string;

  
}