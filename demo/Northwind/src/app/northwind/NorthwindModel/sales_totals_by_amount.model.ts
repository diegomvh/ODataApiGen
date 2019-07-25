
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Sales_Totals_by_Amount extends ODataModel {
  static type = 'NorthwindModel.Sales_Totals_by_Amount';
  static schema = Schema.create({
    keys: [
        'CompanyName', 'OrderID'
    ],
    fields: [
      {name: 'SaleAmount', required: true, type: 'Number'},
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'CompanyName', required: true, type: 'String', length: 40},
      {name: 'ShippedDate', required: true, type: 'Date'}
    ],
    defaults: {}
  });
  SaleAmount: number;
  OrderID: number;
  CompanyName: string;
  ShippedDate: Date;

  
}