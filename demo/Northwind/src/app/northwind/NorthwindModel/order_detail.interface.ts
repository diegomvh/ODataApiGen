import { Order } from './order.interface';
import { Product } from './product.interface';

export interface Order_Detail {
  OrderID: number;
  ProductID: number;
  UnitPrice: number;
  Quantity: number;
  Discount: number;
  Order?: Order;
  Product?: Product;
}