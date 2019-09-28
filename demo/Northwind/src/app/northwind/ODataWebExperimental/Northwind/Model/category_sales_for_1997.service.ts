import { Category_Sales_for_1997 } from '../../../NorthwindModel/category_sales_for_1997.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Category_Sales_for_1997Service extends ODataEntityService<Category_Sales_for_1997> {
  static set: string = 'Category_Sales_for_1997';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Category_Sales_for_1997>) {
    return entity.CategoryName;
  }
  
  
}