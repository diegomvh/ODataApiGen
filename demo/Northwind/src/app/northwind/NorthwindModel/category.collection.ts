import { Category } from './category.model';
import { Collection, ODataCollection } from 'angular-odata';

export class CategoryCollection extends ODataCollection<Category> {
  static type = 'NorthwindModel.CategoryCollection';
  static model = 'NorthwindModel.Category';
}