import { Product_Sales_for_1997 } from '../../../NorthwindModel/product_sales_for_1997.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Product_Sales_for_1997Service extends ODataEntityService<Product_Sales_for_1997> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Product_Sales_for_1997');
  }
  
  protected resolveEntityKey(entity: Partial<Product_Sales_for_1997>) {
    return {CategoryName: entity.CategoryName, ProductName: entity.ProductName};
  }
  
  
}