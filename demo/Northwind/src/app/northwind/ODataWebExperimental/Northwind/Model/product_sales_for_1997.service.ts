import { Product_Sales_for_1997 } from '../../../NorthwindModel/product_sales_for_1997.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Product_Sales_for_1997Service extends ODataEntityService<Product_Sales_for_1997> {
  static set: string = 'Product_Sales_for_1997';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Product_Sales_for_1997>) {
    return {CategoryName: entity.CategoryName, ProductName: entity.ProductName};
  }
  
  
}