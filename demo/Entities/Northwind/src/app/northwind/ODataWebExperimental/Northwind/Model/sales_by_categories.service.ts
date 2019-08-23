import { Sales_by_Category } from '../../../NorthwindModel/sales_by_category.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Sales_by_CategoriesService extends ODataEntityService<Sales_by_Category> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Sales_by_Categories');
  }
  
  protected resolveEntityKey(entity: Partial<Sales_by_Category>) {
    return {CategoryID: entity.CategoryID, CategoryName: entity.CategoryName, ProductName: entity.ProductName};
  }
  
  
}