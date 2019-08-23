import { Order_Subtotal } from './order_subtotal.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Order_SubtotalCollection extends ODataCollection<Order_Subtotal> {
  static type = 'NorthwindModel.Order_SubtotalCollection';
  static modelType = 'NorthwindModel.Order_Subtotal';
}