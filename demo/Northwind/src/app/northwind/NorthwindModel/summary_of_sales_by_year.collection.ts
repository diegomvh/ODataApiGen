import { Summary_of_Sales_by_Year } from './summary_of_sales_by_year.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Summary_of_Sales_by_YearCollection extends ODataCollection<Summary_of_Sales_by_Year> {
  static type = 'NorthwindModel.Summary_of_Sales_by_YearCollection';
  static model = 'NorthwindModel.Summary_of_Sales_by_Year';
}