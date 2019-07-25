import { Sales_Totals_by_Amount } from './sales_totals_by_amount.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Sales_Totals_by_AmountCollection extends ODataCollection<Sales_Totals_by_Amount> {
  static type = 'NorthwindModel.Sales_Totals_by_AmountCollection';
  static model = 'NorthwindModel.Sales_Totals_by_Amount';
}