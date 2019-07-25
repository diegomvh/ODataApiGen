
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Order_Subtotal extends ODataModel {
  static type = 'NorthwindModel.Order_Subtotal';
  static schema = Schema.create({
    keys: [
        'OrderID'
    ],
    fields: [
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'Subtotal', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  OrderID: number;
  Subtotal: number;

  
}