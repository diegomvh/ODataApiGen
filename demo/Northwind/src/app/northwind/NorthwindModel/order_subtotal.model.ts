
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Order_Subtotal extends ODataModel {
  static type = 'NorthwindModel.Order_Subtotal';
  static schema = Schema.create({
    keys: [
      {name: 'OrderID'}
    ],
    fields: [
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'Subtotal', type: 'Number', required: true}
    ]
  });
  OrderID: number;
  Subtotal: number;

  
}