import { Products_by_Category } from '../../../NorthwindModel/products_by_category.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Products_by_CategoriesService extends ODataEntityService<Products_by_Category> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Products_by_Categories');
  }
  
  protected resolveEntityKey(entity: Partial<Products_by_Category>) {
    return {CategoryName: entity.CategoryName, Discontinued: entity.Discontinued, ProductName: entity.ProductName};
  }
  
  
}