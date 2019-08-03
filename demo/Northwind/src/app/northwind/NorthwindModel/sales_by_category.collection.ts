import { Sales_by_Category } from './sales_by_category.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Sales_by_CategoryCollection extends ODataCollection<Sales_by_Category> {
  static type = 'NorthwindModel.Sales_by_CategoryCollection';
  static Model = Sales_by_Category;
}