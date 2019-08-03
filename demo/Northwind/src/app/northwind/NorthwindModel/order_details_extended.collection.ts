import { Order_Details_Extended } from './order_details_extended.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Order_Details_ExtendedCollection extends ODataCollection<Order_Details_Extended> {
  static type = 'NorthwindModel.Order_Details_ExtendedCollection';
  static Model = Order_Details_Extended;
}