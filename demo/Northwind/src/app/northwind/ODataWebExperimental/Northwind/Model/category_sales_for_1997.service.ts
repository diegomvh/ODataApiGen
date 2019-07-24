import { Category_Sales_for_1997 } from '../../../NorthwindModel/category_sales_for_1997.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Category_Sales_for_1997Service extends ODataEntityService<Category_Sales_for_1997> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Category_Sales_for_1997');
  }
  
  protected resolveEntityKey(entity: Partial<Category_Sales_for_1997>) {
    return entity.CategoryName;
  }
  
  
}