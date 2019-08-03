import { Current_Product_List } from './current_product_list.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Current_Product_ListCollection extends ODataCollection<Current_Product_List> {
  static type = 'NorthwindModel.Current_Product_ListCollection';
  static Model = Current_Product_List;
}