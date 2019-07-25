import { Product_Sales_for_1997 } from './product_sales_for_1997.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Product_Sales_for_1997Collection extends ODataCollection<Product_Sales_for_1997> {
  static type = 'NorthwindModel.Product_Sales_for_1997Collection';
  static model = 'NorthwindModel.Product_Sales_for_1997';
}