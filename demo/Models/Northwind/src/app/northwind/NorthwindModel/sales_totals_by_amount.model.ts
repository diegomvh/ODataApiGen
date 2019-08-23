
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Sales_Totals_by_Amount extends ODataModel {
  static type = 'NorthwindModel.Sales_Totals_by_Amount';
  static schema = Schema.create({
    keys: [
      {name: 'CompanyName'},
      {name: 'OrderID'}
    ],
    fields: [
      {name: 'SaleAmount', type: 'Number', required: true},
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'CompanyName', type: 'String', required: true, length: 40},
      {name: 'ShippedDate', type: 'Date', required: true}
    ]
  });
  SaleAmount: number;
  OrderID: number;
  CompanyName: string;
  ShippedDate: Date;

  
}