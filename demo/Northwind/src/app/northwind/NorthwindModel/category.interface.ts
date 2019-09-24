import { Product } from './product.interface';

export interface Category {
  CategoryID: number;
  CategoryName: string;
  Description: string;
  Picture: string;
  Products?: Product[];
}