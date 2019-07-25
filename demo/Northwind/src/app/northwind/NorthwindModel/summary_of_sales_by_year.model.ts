
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Summary_of_Sales_by_Year extends ODataModel {
  static type = 'NorthwindModel.Summary_of_Sales_by_Year';
  static schema = Schema.create({
    keys: [
        'OrderID'
    ],
    fields: [
      {name: 'ShippedDate', required: true, type: 'Date'},
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'Subtotal', required: true, type: 'Number'}
    ],
    defaults: {}
  });
  ShippedDate: Date;
  OrderID: number;
  Subtotal: number;

  
}