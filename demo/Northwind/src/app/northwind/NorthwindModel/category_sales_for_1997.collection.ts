import { Category_Sales_for_1997 } from './category_sales_for_1997.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Category_Sales_for_1997Collection extends ODataCollection<Category_Sales_for_1997> {
  static type = 'NorthwindModel.Category_Sales_for_1997Collection';
  static Model = Category_Sales_for_1997;
}