import { Order } from './order.interface';

export interface Shipper {
  ShipperID: number;
  CompanyName: string;
  Phone: string;
  Orders?: Order[];
}