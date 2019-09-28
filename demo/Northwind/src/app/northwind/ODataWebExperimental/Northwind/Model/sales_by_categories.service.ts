import { Sales_by_Category } from '../../../NorthwindModel/sales_by_category.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Sales_by_CategoriesService extends ODataEntityService<Sales_by_Category> {
  static set: string = 'Sales_by_Categories';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Sales_by_Category>) {
    return {CategoryID: entity.CategoryID, CategoryName: entity.CategoryName, ProductName: entity.ProductName};
  }
  
  
}