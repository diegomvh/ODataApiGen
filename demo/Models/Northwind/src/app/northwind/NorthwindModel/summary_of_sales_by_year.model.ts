
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Summary_of_Sales_by_Year extends ODataModel {
  static type = 'NorthwindModel.Summary_of_Sales_by_Year';
  static schema = Schema.create({
    keys: [
      {name: 'OrderID'}
    ],
    fields: [
      {name: 'ShippedDate', type: 'Date', required: true},
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'Subtotal', type: 'Number', required: true}
    ]
  });
  ShippedDate: Date;
  OrderID: number;
  Subtotal: number;

  
}