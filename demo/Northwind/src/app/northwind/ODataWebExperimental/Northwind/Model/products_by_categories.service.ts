import { Products_by_Category } from '../../../NorthwindModel/products_by_category.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Products_by_CategoriesService extends ODataEntityService<Products_by_Category> {
  static set: string = 'Products_by_Categories';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Products_by_Category>) {
    return {CategoryName: entity.CategoryName, Discontinued: entity.Discontinued, ProductName: entity.ProductName};
  }
  
  
}