import { Summary_of_Sales_by_Quarter } from './summary_of_sales_by_quarter.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Summary_of_Sales_by_QuarterCollection extends ODataCollection<Summary_of_Sales_by_Quarter> {
  static type = 'NorthwindModel.Summary_of_Sales_by_QuarterCollection';
  static Model = Summary_of_Sales_by_Quarter;
}