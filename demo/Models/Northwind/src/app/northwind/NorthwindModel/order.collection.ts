import { Order } from './order.model';
import { Collection, ODataCollection } from 'angular-odata';

export class OrderCollection extends ODataCollection<Order> {
  static type = 'NorthwindModel.OrderCollection';
  static modelType = 'NorthwindModel.Order';
}