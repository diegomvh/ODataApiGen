import { Products_by_Category } from './products_by_category.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Products_by_CategoryCollection extends ODataCollection<Products_by_Category> {
  static type = 'NorthwindModel.Products_by_CategoryCollection';
  static model = 'NorthwindModel.Products_by_Category';
}