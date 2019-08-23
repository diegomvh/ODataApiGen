import { Product } from './product.model';
import { Collection, ODataCollection } from 'angular-odata';

export class ProductCollection extends ODataCollection<Product> {
  static type = 'NorthwindModel.ProductCollection';
  static modelType = 'NorthwindModel.Product';
}