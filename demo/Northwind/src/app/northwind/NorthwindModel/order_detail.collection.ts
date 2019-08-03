import { Order_Detail } from './order_detail.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Order_DetailCollection extends ODataCollection<Order_Detail> {
  static type = 'NorthwindModel.Order_DetailCollection';
  static Model = Order_Detail;
}