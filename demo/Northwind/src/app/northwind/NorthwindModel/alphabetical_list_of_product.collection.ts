import { Alphabetical_list_of_product } from './alphabetical_list_of_product.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Alphabetical_list_of_productCollection extends ODataCollection<Alphabetical_list_of_product> {
  static type = 'NorthwindModel.Alphabetical_list_of_productCollection';
  static model = 'NorthwindModel.Alphabetical_list_of_product';
}