import { Category } from './category.interface';
import { Order_Detail } from './order_detail.interface';
import { Supplier } from './supplier.interface';

export interface Product {
  ProductID: number;
  ProductName: string;
  SupplierID: number;
  CategoryID: number;
  QuantityPerUnit: string;
  UnitPrice: number;
  UnitsInStock: number;
  UnitsOnOrder: number;
  ReorderLevel: number;
  Discontinued: boolean;
  Category?: Category;
  Order_Details?: Order_Detail[];
  Supplier?: Supplier;
}