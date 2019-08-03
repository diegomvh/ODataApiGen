import { Products_Above_Average_Price } from './products_above_average_price.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Products_Above_Average_PriceCollection extends ODataCollection<Products_Above_Average_Price> {
  static type = 'NorthwindModel.Products_Above_Average_PriceCollection';
  static Model = Products_Above_Average_Price;
}